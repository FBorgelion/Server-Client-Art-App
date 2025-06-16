using BL.Models;
using BL.Services;
using BL.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("assigned")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "DeliveryPartner,Admin")]
        public IActionResult GetAssigned()
        {
            try
            {
                var partnerIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(partnerIdClaim, out var partnerId))
                    return Unauthorized();
                var dtos = _orderService.GetAssignedOrders(partnerId);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{orderId}/dp/status")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "DeliveryPartner,Admin")]

        public async Task<IActionResult> UpdateStatusDp(int orderId, [FromBody] StatusUpdateDTO dto)
        {
            try
            {
                var partnerIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(partnerIdClaim, out var partnerId))
                    return Unauthorized();
                var res = await _orderService.UpdateOrderStatus(orderId, partnerId, dto.Status);
                return res ? NoContent() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<OrderDTO> orders = _orderService.GetAll();
                if (orders.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _orderService.Get(id);
                if (order == null)
                {
                    return NoContent();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("customers/{customerId}/orders")]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOrderByCustomer(int customerId)
        {
            try
            {
                IEnumerable<OrderDTO> orders = _orderService.GetOrdersByCustomer(customerId);
                if (orders == null)
                {
                    return NotFound($"No orders found for customer {customerId}");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("customers/orders")]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCustomerOrders()
        {
            try
            {
                var custIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(custIdClaim, out var custId))
                    return Unauthorized();
                var orders = _orderService.GetOrdersByCustomer(custId);
                if (orders == null)
                {
                    return NotFound($"No orders found for customer {custId}");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("delivery-partners/{partnerId}/orders")]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOrderByPartner(int partnerId)
        {
            try
            {
                IEnumerable<OrderDTO> orders = _orderService.GetOrdersByPartner(partnerId);
                if (orders == null)
                {
                    return NotFound($"No orders found for customer {partnerId}");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] OrderDTO order)
        {
            try
            {
                _orderService.Add(order);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _orderService.Delete(id);
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

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public ActionResult Update([FromBody] OrderDTO order)
        //{
        //    try
        //    {
        //        bool updated = _orderService.Update(order);
        //        if (!updated)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound);
        //        }
        //        return Ok(order);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult UpdateStatus(int id, [FromBody] StatusUpdateDTO dto)
        {
            try
            {
                if (dto == null || string.IsNullOrWhiteSpace(dto.Status))
                    return BadRequest("Missing status");

                var ok = _orderService.UpdateOrderStatus(id, dto.Status);
                if (!ok)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("revenue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetRevenue([FromQuery] string period)
        {
            var artIdClaim = User.FindFirst("userId")?.Value;
            if (!int.TryParse(artIdClaim, out var artId))
                return Unauthorized();

            var data = _orderService.GetRevenue(artId, period);
            if (!data.Any())
                return NoContent();

            return Ok(data);
        }
    }




}
