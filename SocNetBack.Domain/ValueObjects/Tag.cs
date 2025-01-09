using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class Tag : ValueObject
{
    public string Value { get; }

    private Tag(string value)
    {
        Value = value;
    }

    public Result<Tag> Create(string value)
    {
        var validationResult = IsValid(value);
        
        if (validationResult.IsFailure)
            return Result.Failure<Tag>(validationResult.Error);

        return Result.Success(new Tag(value));
    }

    private Result IsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure("Tag cannot be empty");

        if (value.Contains(' '))
        {
            return Result.Failure("Tag cannot contain spaces");
        }

        if (value[0] != '#')
        {
            return Result.Failure("Tag must start with '#'");
        }
        
        return Result.Success();
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}