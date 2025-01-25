using System.ComponentModel.DataAnnotations;
using SocNetBack.Domain.Models;

namespace SocNetBack.API.Contracts;

public record CreateUserRequest(string FirstName, string LastName, string? Username,
    string? Email, string? Phone, string Password, DateTime? Birthday,
    string Gender, string? Country, string? Region, string? City);