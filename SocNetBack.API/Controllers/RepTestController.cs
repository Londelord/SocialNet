using Microsoft.AspNetCore.Mvc;
using SocNetBack.Application.Services;
using SocNetBack.Domain.Models;
using SocNetBack.Data.Repositories;

namespace SocNetBack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepTestController
{
    private readonly UserService _userService;

    public RepTestController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<User?> GetUser(Guid userId)
    {
        var g = _userService.Get(userId);
        
        
        return await _userService.Get(userId);
    }
}