using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Country { get; }
    
    public string Region { get; }
    
    public string City { get; }

    private Address(string country, string region, string city)
    {
        Country = country;
        Region = region;
        City = city;
    }

    public static Result<Address> Create(string country, string region, string city)
    {
        var validationResult = IsValidResult(country, region, city);
        
        if (validationResult.IsFailure)
            return Result.Failure<Address>(validationResult.Error);
        
        return Result.Success(new Address(country, region, city));
    }

    private static Result IsValidResult(string country, string region, string city)
    {
        throw new NotImplementedException();
    }
    
    
    public static bool IsValid(string country, string region, string city) => 
        IsValidResult(country, region, city).IsSuccess;

    public bool IsValid() => IsValidResult(Country, Region, City).IsSuccess;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return Region;
        yield return City;
        
    }
}