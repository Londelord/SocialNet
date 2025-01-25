using CSharpFunctionalExtensions;
using SocNetBack.Domain.Models;

namespace SocNetBack.Domain.Stores;

public interface IUserStore
{
    Task<User?> GetById(Guid userId);
    Task<Result> RegisterUser(User user, string hashedPassword);
    Task<Result> IsUserExist(string? email, string? username);
    Task<User?> GetByEmail(string email);
    Task<string> GetPasswordHash(Guid? userId);
    Task<Result> WriteAccessToken(User user, string token);
}