using CSharpFunctionalExtensions;
using SocNetBack.Domain.Stores;

namespace SocNetBack.Data.Repositories;

public class TokensRepository : ITokenStore
{
    public async Task<Result> TokenValidate(string token)
    {
        throw new NotImplementedException();
    }
}