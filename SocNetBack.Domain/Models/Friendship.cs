using CSharpFunctionalExtensions;
using SocNetBack.Domain.Models;

namespace SocNetBack.Domain.Models;

public class Friendship 
{
    //TODO - implement
  
    public Guid UserId { get; }
    public Guid FriendId { get; }
    public DateTime CreatedAt { get; }

    private Friendship(Guid userId, Guid friendId, DateTime createdAt)
    {
        UserId = userId;
        FriendId = friendId;
        CreatedAt = createdAt;
    }

    public static Result<Friendship> Create(Guid userId, Guid friendId, DateTime createdAt)
    {
        var validationResult = IsValid(createdAt);
        
        if (validationResult.IsFailure)
            return Result.Failure<Friendship>(validationResult.Error);
        
        return Result.Success(new Friendship(userId, friendId, createdAt));
    }

    private static Result IsValid(DateTime createdAt)
    {
        if (createdAt > DateTime.UtcNow)
            return Result.Failure("Created time must not be in the future.");
        
        return Result.Success();
    }
}