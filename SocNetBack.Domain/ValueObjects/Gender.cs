using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class Gender : ValueObject
{
    public static readonly Gender Male = new(nameof(Male));
    public static readonly Gender Female = new(nameof(Female));
    public static readonly Gender NotSpecified = new(nameof(NotSpecified));

    private static readonly Gender[] _all = [Male, Female, NotSpecified];
    
    public string Value { get; }
   
    private Gender(string value)
    {
        Value = value;
    }

    public static Result<Gender> Create(string value)
    {
        var validationResult = IsValidResult(value);
        
        if (validationResult.IsFailure)
            return Result.Failure<Gender>(validationResult.Error);

        return Result.Success(new Gender(value));
    }

    private static Result IsValidResult(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure("Gender value cannot be null or empty.");

        var gender = value.Trim().ToLower();
        
        if (_all.Any(g => g.Value.ToLower() == gender) == false)
            return Result.Failure("Gender value is not valid.");
        
        return Result.Success();
    }
    
    public static bool IsValid(string value) => IsValidResult(value).IsSuccess;
    
    public override string ToString() => Value;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}