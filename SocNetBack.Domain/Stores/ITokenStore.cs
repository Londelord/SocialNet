using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.Stores;

public interface ITokenStore
{
    Task<Result> TokenValidate(string token);
}