using System.ComponentModel.DataAnnotations;

namespace SocNetBack.API.Contracts;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);