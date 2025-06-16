using BL.Models;
using BL.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public IActionResult GetAllProducts()
        {
            try
            {
                IEnumerable<ProductDTO> products = _productService.GetAllProducts();
                if (products.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}/products")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public IActionResult GetProductByArtisan(int id)
        {
            try
            {
                var product = _productService.GetProductsByArtisan(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("artisan")]
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Artisan,Admin")]

        public IActionResult GetProductByArtisan()
        {
            try
            {
                var artisanIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(artisanIdClaim, out var artisanId))
                    return Unauthorized();
                var products = _productService.GetProductsByArtisan(artisanId);
                if (products == null)
                {
                    return NotFound($"No products found for artisan {artisanId}");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Artisan,Admin")]
        public async Task<IActionResult> Post([FromBody] ProductCreateDTO dto)
        {
            var artisanIdClaim = User.FindFirst("userId")?.Value;
            if (!int.TryParse(artisanIdClaim, out var artisanId))
                return Unauthorized();

            var created = await _productService.CreateAsync(dto, artisanId);
            return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                bool deleted = _productService.DeleteProduct(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Artisan,Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDTO dto)
        {
            await _productService.UpdateAsync(id, dto);
            return Ok();
        }

    }
}
