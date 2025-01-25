namespace SocNetBack.Application.Commands;

public record CreateUserCommand(string FirstName, string LastName, string? Username,
    string? Email, string? Phone, string Password, DateTime? Birthday,
    string Gender, string? Country, string? Region, string? City);