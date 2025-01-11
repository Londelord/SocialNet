using CSharpFunctionalExtensions;
using SocNetBack.Domain.Models;

namespace SocNetBack.Domain.Stores;

public interface IUserStore
{
    Task<User?> GetById(Guid userId);
    Task<Result> CreateUser(User user);
    Task<Result> IsUserExist(string? email, string? username);
}