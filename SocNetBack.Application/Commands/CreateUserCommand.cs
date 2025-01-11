namespace SocNetBack.Application.Commands;

public record CreateUserCommand(string FirstName, string LastName, string? Username,
    string? Email, string? Phone, string PasswordHash, string Salt, DateTime? Birthday,
    string Gender, string? Country, string? Region, string? City);