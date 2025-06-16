using BL.Models;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<CustomerDTO> customers = _customerService.GetAll();
                if (customers.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Customer, Admin")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var custIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(custIdClaim, out var custId))
                    return Unauthorized();
                var customer = await _customerService.Get(custId);
                if (customer == null)
                {
                    return NoContent();
                }
                return Ok(customer);
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
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] CustomerDTO customer)
        {
            try
            {
                _customerService.Add(customer);
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
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _customerService.Delete(id);
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<ActionResult> Update([FromBody] CustomerDTO customer)
        {
            try
            {
                bool updated = await _customerService.Update(customer);
                if (!updated)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("profile")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> UpdateProfile([FromBody] CustomerUpdDTO dto)
        {
            var claim = User.FindFirst("userId")?.Value;
            if (!int.TryParse(claim, out var customerId))
                return Unauthorized();

            var ok = await _customerService.UpdateProfile(customerId, dto);
            if (!ok) return NotFound();
            return NoContent();
        }

    }
}
