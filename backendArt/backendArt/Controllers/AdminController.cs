using BL.Models;
using BL.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminservice;

        public AdminController(IAdminService adminService)
        {
            _adminservice = adminService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] AdminDTO admin)
        {
            try
            {
                _adminservice.Add(admin);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
