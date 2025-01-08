using Microsoft.AspNetCore.Mvc;
using SocNetBack.Application.Services;

namespace SocNetBack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    
    private readonly UserService _userService;

    public AuthenticationController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public IActionResult Login([FromBody] Contracts.MyLoginRequest loginRequest, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}