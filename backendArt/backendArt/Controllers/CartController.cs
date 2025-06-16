using BL.Models;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer, Admin")]
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IProductService productService, IOrderService orderService) 
        { 
            _cartService = cartService;    
            _productService = productService;
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CartDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<ActionResult<IEnumerable<CartDTO>>> Get()
        {
            try
            {
                var custIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(custIdClaim, out var custId))
                    return Unauthorized();
                var cart =await _cartService.GetCart(custId);
                if (cart == null)
                {
                    return NoContent();
                }
                return Ok(cart);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Add([FromBody] AddCartDTO dto)
        {
            try
            {
                var custIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(custIdClaim, out var custId))
                    return Unauthorized();

                _cartService.AddItem(custId, dto.ProductId, dto.Quantity);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{cartId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Remove(int cartId)
        {
            if (!_cartService.RemoveItem(cartId))
                return NotFound();
            return Ok();
        }

        [HttpDelete]
        [Route("clear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Clear()
        {
            var custIdClaim = User.FindFirst("userId")?.Value;
            if (!int.TryParse(custIdClaim, out var custId))
                return Unauthorized();
            _cartService.ClearCart(custId);
            return Ok();
        }

        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Checkout()
        {
            if (!int.TryParse(User.FindFirst("userId")?.Value, out var customerId))
                return Unauthorized();

            var success = await _orderService.CreateOrderFromCart(customerId);
            if (!success)
                return BadRequest("Cart empty or no stock");

            return Ok();
        }

    }
}
