using Microsoft.AspNetCore.Mvc;
using SocNetBack.API.Contracts;
using SocNetBack.Application.Services;

namespace SocNetBack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly UserService _userService;

    public RegistrationController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> LoginValidate([FromQuery] string? email, [FromQuery] string? username)
    {
        
        return Ok();
    }
    
    private string CreateUsername()
    {
        throw new NotImplementedException();
    }
}