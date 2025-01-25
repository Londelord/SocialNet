using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocNetBack.Application.Services;
using SocNetBack.Domain.Models;
using SocNetBack.Data.Repositories;

namespace SocNetBack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepTestController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ILogger<RepTestController> _logger;

    public RepTestController(UserService userService, ILogger<RepTestController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<User?> GetUser(Guid userId)
    {
        return await _userService.Get(userId);
    }

    [HttpGet("user-agent")]
    public IActionResult GetUserAgent()
    {
        var agent = HttpContext.Request.Headers.UserAgent;
        _logger.LogInformation($"User-Agent: {agent}");
        var ip = HttpContext.Connection.RemoteIpAddress.ToString();
        _logger.LogInformation($"IP: {ip}");
        
        return Ok();
    }
}