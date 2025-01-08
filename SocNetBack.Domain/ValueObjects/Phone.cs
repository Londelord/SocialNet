using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class Phone : ValueObject
{
    public string Value { get; }
    
    public const int MIN_PHONE_LENGTH = 10;
    public const int MAX_PHONE_LENGTH = 20;

    private Phone(string value)
    {
        Value = value;
    }

    public static Result<Phone> Create(string phoneNumber)
    {
        var validationResult = IsValidResult(phoneNumber);
        
        if (validationResult.IsFailure)
            return Result.Failure<Phone>(validationResult.Error);
        
        return Result.Success(new Phone(phoneNumber));
    }

    private static Result IsValidResult(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return Result.Failure("Phone number must not be empty");
        
        
        //@"^\d{10,15}$"
        string pattern = @"^\d{" + $"{MIN_PHONE_LENGTH},{MAX_PHONE_LENGTH}" + "}$";
        if (!Regex.IsMatch(phoneNumber, pattern))
            return Result.Failure("Phone number is invalid");
        
        return Result.Success();
    }
    
    public override string ToString() => Value;

    public static bool IsValid(string phoneNumber) => IsValidResult(phoneNumber).IsSuccess;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}