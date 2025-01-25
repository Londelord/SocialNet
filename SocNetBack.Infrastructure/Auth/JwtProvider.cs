using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocNetBack.Application.Interfaces;
using SocNetBack.Domain.Models;

namespace SocNetBack.Infrastructure.Auth;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public string GenerateJwtToken(User user)
    {
        Claim[] claims = [new ("userId", user.UserId.ToString())];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), 
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours));
        
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        
        return tokenValue;
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var validationResult = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            
            if (validatedToken is JwtSecurityToken jwtToken)
            {
                var claims = jwtToken.Claims.ToList();
                return new ClaimsPrincipal(new ClaimsIdentity(claims, "Token"));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return null;
    }
}

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiresHours { get; set; }
}