using BL.Models;
using BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AuthenticationService _authService;

        public AuthenticationController(ILogger<AuthenticationController> logger, AuthenticationService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<UserDTO> users = _authService.GetAll();
                if (users.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register(string password, string username, string email, string role)
        {
            try
            {
                _authService.Register(password, username, email, role);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("LogIn")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            var token = _authService.Login(username, password);
            return Ok(new { Token = token });
        }
    }
}
