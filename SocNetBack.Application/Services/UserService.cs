using CSharpFunctionalExtensions;
using SocNetBack.Application.Commands;
using SocNetBack.Domain.Models;
using SocNetBack.Domain.Stores;
using SocNetBack.Domain.ValueObjects;

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

    public async Task<Result> CreateUser(CreateUserCommand command)
    {
        var email = command.Email is null ? null : Email.Create(command.Email).Value;
        var phone = command.Phone is null ? null : Phone.Create(command.Phone).Value;
        var gender = Gender.Create(command.Gender).Value;
        var address = command.Country is null ? null : 
            Address.Create(command.Country, command.Region!, command.City!).Value;

        var username = command.Username ?? CreateUsername();
        
        var user = User.Create(
            Guid.NewGuid(),
            username,
            email,
            phone,
            command.FirstName,
            command.LastName,
            command.Birthday,
            gender,
            null,
            null,
            address,
            DateTime.UtcNow,
            false,
            [],
            []
        );
        
        var result = await _userStore.CreateUser(user.Value);
        
        return result;
    }

    public string CreateUsername()
    {
        throw new NotImplementedException();
    }

    public async Task<Result> IsUserExist(string? email, string? username)
    {
        return await _userStore.IsUserExist(email, username);
    }
}