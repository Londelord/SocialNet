using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class Restriction : ValueObject
{
    public string Value { get; }
    
    public static readonly Restriction Erotic = new(nameof(Erotic));
    public static readonly Restriction Violent = new(nameof(Violent));
    
    private static readonly Restriction[] Restrictions = [Erotic, Violent];

    private Restriction(string value)
    {
        Value = value;
    }

    public static Result<Restriction> Create(string value)
    {
        var validationResult = IsValidResult(value);
        
        if (validationResult.IsFailure)
            return Result.Failure<Restriction>(validationResult.Error);

        return Result.Success(new Restriction(value));
    }

    private static Result IsValidResult(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Restriction>("Value cannot be null or whitespace.");
        
        var restriction = value.Trim().ToLower();
        
        if(Restrictions.Any(r => r.Value.ToLower() == restriction) == false)
            return Result.Failure<Restriction>("Value is not a valid restriction.");
        
        return Result.Success();
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}