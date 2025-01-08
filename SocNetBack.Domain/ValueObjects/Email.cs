using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }
    
    public const int MAX_EMAIL_LENGTH = 255;

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email?> Create(string email)
    {
        var validationResult = IsValidResult(email);
        if (validationResult.IsFailure)
            return Result.Failure<Email>(validationResult.Error);
        
        return Result.Success(new Email(email));
    }

    private static Result IsValidResult(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            return Result.Failure("Email is invalid");

        if (email.Length > MAX_EMAIL_LENGTH)
            return Result.Failure($"Email length must be less than {MAX_EMAIL_LENGTH} characters");

        return Result.Success();
    }

    public override string ToString() => Value;
    
    public static bool IsValid(string email) => IsValidResult(email).IsSuccess;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}