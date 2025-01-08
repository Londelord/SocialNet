using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using SocNetBack.Application.Services;

namespace SocNetBack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RootController : ControllerBase
{
    private readonly UserService _userService;

    public RootController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult SMTPTest([FromQuery] string title, [FromQuery] string message, CancellationToken cancellationToken = default)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("saidrahmanovinput@gmail.com", "tcyx zjax fxmv rzrt"),
                EnableSsl = true,
            };
            
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("saidrahmanovinput@gmail.com"),
                Subject = title,
                Body = message,
                IsBodyHtml = false,
            };
            
            mail.To.Add("saidrahmanovfrance@gmail.com");
            
            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return Ok();
        
    }
}