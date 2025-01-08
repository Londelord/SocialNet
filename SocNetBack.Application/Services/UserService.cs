using SocNetBack.Domain.Models;
using SocNetBack.Domain.Stores;

namespace SocNetBack.Application.Services;

public class UserService
{
    private readonly IUserStore _userStore;
    
    public UserService(IUserStore userStore)
    {
        _userStore = userStore;
    }

    public async Task<User?> Get(Guid userId)
    {
        return await _userStore.GetById(userId);
    }
}