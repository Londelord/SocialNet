using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SocNetBack.API.Contracts;
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
    public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
    {
        var token = await _userService.Login(loginUserRequest.Email, loginUserRequest.Password);
        
        HttpContext.Response.Cookies.Append("fruity", token);
        
        return Ok();
    }
}