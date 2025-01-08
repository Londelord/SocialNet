using SocNetBack.Domain.Models;

namespace SocNetBack.Domain.Stores;

public interface IUserStore
{
    Task<User?> GetById(Guid userId);
}