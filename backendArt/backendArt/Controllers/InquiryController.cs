using BL.Models;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiryController : ControllerBase
    {

        private readonly IInquiryService _inquiryService;

        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InquiryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<InquiryDTO> inquiries = _inquiryService.GetAll();
                if (inquiries.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(inquiries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<InquiryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get(int id)
        {
            try
            {
                var inquiry = _inquiryService.Get(id);
                if (inquiry == null)
                {
                    return NoContent();
                }
                return Ok(inquiry);
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
        public IActionResult Post([FromBody] InquiryDTO inquiry)
        {
            try
            {
                _inquiryService.Add(inquiry);
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
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _inquiryService.Delete(id);
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
        public ActionResult Update([FromBody] InquiryDTO artisan)
        {
            try
            {
                bool updated = _inquiryService.Update(artisan);
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

        [HttpGet("artisan")]
        [Authorize(Roles = "Artisan,Admin")]
        public ActionResult<IEnumerable<InquiryDTO>> GetForArtisan()
        {
            var artisanIdClaim = User.FindFirst("userId")?.Value;
            if (!int.TryParse(artisanIdClaim, out var artisanId))
                return Unauthorized();
            var dtos = _inquiryService.GetInquiriesForArtisan(artisanId);
            return Ok(dtos);
        }

        [HttpPut("{id}/response")]
        [Authorize(Roles = "Artisan,Admin")]
        public IActionResult Respond(int id, [FromBody] ResponseDTO resp)
        {
            if (string.IsNullOrWhiteSpace(resp.Response))
                return BadRequest();

            var ok = _inquiryService.RespondToInquiry(id, resp.Response);
            if (!ok) return NotFound();
            return NoContent();
        }

    }
}
