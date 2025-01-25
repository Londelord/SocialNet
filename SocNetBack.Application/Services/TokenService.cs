using CSharpFunctionalExtensions;
using SocNetBack.Application.Interfaces;
using SocNetBack.Domain.Stores;

namespace SocNetBack.Application.Services;

public class TokenService
{
    private readonly ITokenStore _tokenStore;
    private readonly IJwtProvider _jwtProvider;

    public TokenService(ITokenStore tokenStore, IJwtProvider jwtProvider)
    {
        _tokenStore = tokenStore;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result> Validate(string token)
    {
        return Result.Success();
    }
}