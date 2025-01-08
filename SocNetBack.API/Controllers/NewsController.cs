using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocNetBack.Application.Services;

namespace SocNetBack.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class NewsController : ControllerBase
{
    private readonly UserService _userService;

    public NewsController(UserService userService)
    {
        _userService = userService;
    }
    
} 