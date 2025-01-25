using CSharpFunctionalExtensions;
using SocNetBack.Application.Commands;
using SocNetBack.Application.Interfaces;
using SocNetBack.Domain.Models;
using SocNetBack.Domain.Stores;
using SocNetBack.Domain.ValueObjects;

namespace SocNetBack.Application.Services;

public class UserService
{
    private readonly IUserStore _userStore;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UserService(IUserStore userStore, 
        IPasswordHasher passwordHasher, 
        IJwtProvider jwtProvider)
    {
        _userStore = userStore;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<User?> Get(Guid userId)
    {
        Console.WriteLine(_passwordHasher.Generate("qwerty"));
        return await _userStore.GetById(userId);
    }

    public async Task<Result> RegisterUser(CreateUserCommand command)
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
        
        var hashedPassword = _passwordHasher.Generate(command.Password);
        
        var result = await _userStore.RegisterUser(user.Value, hashedPassword);
        
        return result;
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _userStore.GetByEmail(email);
        var hashedPassword = await _userStore.GetPasswordHash(user!.UserId);
        
        var result = _passwordHasher.Verify(password, hashedPassword);
        
        if (result == false)
            throw new UnauthorizedAccessException();

        var token = _jwtProvider.GenerateJwtToken(user);
        
        await _userStore.WriteAccessToken(user, token);
        
        return token;
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