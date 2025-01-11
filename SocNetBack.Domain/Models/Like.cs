using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.Models;

public class Like
{
    public Guid UserId { get; }
    public Guid PostId { get; }
    public DateTime CreatedAt { get; }

    private Like(Guid userId, Guid postId, DateTime createdAt)
    {
        UserId = userId;
        PostId = postId;
        CreatedAt = createdAt;
    }

    public static Result<Like> Create(Guid userId, Guid postId, DateTime createdAt)
    {
        var validationResult = IsValid(createdAt);
        
        if (validationResult.IsFailure)
            return Result.Failure<Like>(validationResult.Error);
        
        return Result.Success(new Like(userId, postId, createdAt));
    }

    private static Result IsValid(DateTime createdAt)
    {
        if (createdAt > DateTime.UtcNow)
            return Result.Failure("Created time must not be in the future.");
        
        return Result.Success();
    }
}