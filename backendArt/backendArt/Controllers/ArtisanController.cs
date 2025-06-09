using BL.Models;
using BL.Services;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ArtisanController : ControllerBase
    {

        private readonly IArtisanService _artisanService;
        private readonly IOrderService _orderService;

        public ArtisanController(IArtisanService artisanService, IOrderService orderService)
        {
            _artisanService = artisanService;
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ArtisanDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<ArtisanDTO> artisans = _artisanService.GetAll();
                if (artisans.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(artisans);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(IEnumerable<ArtisanDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult Get()
        {
            try
            {
                var artisanIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(artisanIdClaim, out var artisanId))
                    return Unauthorized();
                var artisan = _artisanService.Get(artisanId);
                if (artisan == null)
                {
                    return NoContent();
                }
                return Ok(artisan);
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
        public IActionResult Post([FromBody] ArtisanDTO artisan)
        {
            try
            {
                _artisanService.Add(artisan);
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
                bool deleted = _artisanService.Delete(id);
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
        public ActionResult Update([FromBody] ArtisanDTO artisan)
        {
            try
            {
                bool updated = _artisanService.Update(artisan);
                if (!updated)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return Ok(artisan);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("orders")]
        [ProducesResponseType(typeof(IEnumerable<ArtisanDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult GetById()
        {
            try
            {
                var artisanIdClaim = User.FindFirst("userId")?.Value;
                if (!int.TryParse(artisanIdClaim, out var artisanId))
                    return Unauthorized();

                var orders = _orderService.GetOrdersForArtisanAsync(artisanId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("description")]
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult UpdateDescription([FromBody] ArtisanDTO dto)
        {
            var artisanIdClaim = User.FindFirst("userId")?.Value;
            if (!int.TryParse(artisanIdClaim, out var artisanId))
                return Unauthorized();
            if (dto == null)
                return BadRequest();

            var ok = _artisanService.UpdateDescription(artisanId, dto.ProfileDescription);
            if (!ok) return NotFound();
            return NoContent();
        }

    }

}
