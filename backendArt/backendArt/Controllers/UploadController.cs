using BL.Models;
using BL.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace backendArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment _env)
        {
            _env = _env;
        }

        [HttpPost("image")]
        [RequestSizeLimit(5_000_000)]     
        [RequestFormLimits(MultipartBodyLengthLimit = 5_000_000)]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file.");

            var uploads = Path.Combine(_env.WebRootPath, "images");
            Directory.CreateDirectory(uploads);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(uploads, fileName);
            using var fs = System.IO.File.Create(path);
            file.CopyTo(fs);

            var url = $"/images/{fileName}";
            return Ok(new { url });
        }

    }
}
