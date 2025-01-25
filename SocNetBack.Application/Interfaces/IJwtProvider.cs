using System.Security.Claims;
using SocNetBack.Domain.Models;

namespace SocNetBack.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
    ClaimsPrincipal ValidateToken(string token);
}