using Microsoft.AspNetCore.Mvc;
using SocNetBack.API.Contracts;
using SocNetBack.Application.Commands;
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
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand
        (
            request.FirstName,
            request.LastName,
            request.Username,
            request.Email,
            request.Phone,
            request.Password,
            request.Birthday,
            request.Gender,
            request.Country,
            request.Region,
            request.City
        );

        var result = await _userService.RegisterUser(command);
        
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> IsUserExist([FromQuery] string? email, [FromQuery] string? username)
    {
        if (username is null && email is null)
            return BadRequest("Data for validation is required");
        
        var result = await _userService.IsUserExist(email, username);
        
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok();
    }
}