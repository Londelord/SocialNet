using Microsoft.AspNetCore.Mvc;
using SocNetBack.Domain.Models;

namespace SocNetBack.API.Controllers;


[ApiController]
[Route("[controller]")]
public class MediaController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public MediaController(IWebHostEnvironment env)
    {
        _env = env;
    }
   
    
    [HttpGet("download/{fileName}")]
    public IActionResult Download(string fileName)
    {
        
        var filePath = Path.Combine(_env.WebRootPath, "Media", fileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File not found");
        }
        
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var contentType = "image/jpeg";
        return File(fileBytes, contentType, fileName);
    }
    
}
