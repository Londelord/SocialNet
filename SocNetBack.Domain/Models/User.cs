using CSharpFunctionalExtensions;
using SocNetBack.Domain.ValueObjects;

namespace SocNetBack.Domain.Models;

public class User
{
    private User(Guid userId, string username, Email? email, Phone? phone, string firstName, 
        string lastName, DateTime? birthDate, Gender gender, ImageFile? profilePicture, 
        string? bio, Address? address, DateTime createdAt, bool verificationStatus, 
        List<Friendship> friendships, List<Like> likes)
    {
        UserId = userId;
        Username = username;
        Email = email;
        Phone = phone;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Gender = gender;
        ProfilePicture = profilePicture;
        Bio = bio;
        Address = address;
        CreatedAt = createdAt;
        VerificationStatus = verificationStatus;
        _friendships = friendships;
        _likes = likes;
    }
    
    public Guid UserId { get; }
    public string Username { get; private set; }
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public ImageFile? ProfilePicture { get; }
    public string? Bio { get; }
    public Address? Address { get; private set; }
    public DateTime CreatedAt { get; }
    public bool VerificationStatus { get; }
    
    private List<Friendship> _friendships = new();
    public IReadOnlyCollection<Friendship> Friendships => _friendships;
    
    private List<Like> _likes = new();
    public IReadOnlyCollection<Like> Likes => _likes;
    
    //TODO add management methods
    
    #region Validation constants

    public const int MIN_USERNAME_LENGTH = 5;
    public const int MAX_USERNAME_LENGTH = 30;
    
    
    #endregion

     public static Result<User> Create(Guid userId, string username, Email? email, Phone? phone, string firstName,
        string lastName, DateTime? birthDate, Gender gender, ImageFile? profilePicture,
        string? bio, Address? address, DateTime createdAt, bool verificationStatus, List<Friendship> friendships, List<Like> likes)
     {
         var validationResult = IsValid(userId, username, email, phone, birthDate, friendships, likes);
         
         if (validationResult.IsFailure)
             return Result.Failure<User>(validationResult.Error);
        
        var user = new User(userId, username, email, phone, firstName, lastName, birthDate,
            gender, profilePicture, bio, address, createdAt, verificationStatus, friendships, likes);
        return Result.Success(user);
    }

    private static Result IsValid(Guid userId, string username, Email? email, Phone? phone, 
        DateTime? birthDate, List<Friendship> friendships, List<Like> likes)
    {
        if (username.Length > MAX_USERNAME_LENGTH || username.Length < MIN_USERNAME_LENGTH) 
            return Result.Failure("Username must be between 5 and 30 characters");
        
        if (email is null && phone is null)
            return Result.Failure("Email or phone are required");
        
        if (birthDate is not null && birthDate > DateTime.Today)
            return Result.Failure("Birth date cannot be in the future");

        if (friendships.Any(friendship => friendship.UserId != userId))
            return Result.Failure("Friendship does not belong to the user");
        
        if (likes.Any(like => like.UserId != userId))
            return Result.Failure("Like does not belong to the user");
        
        return Result.Success();
    }

    public Result ChangeEmail(Email email)
    {
        Email = email;
        
        return Result.Success();
    }

    public Result ChangePhone(Phone phone)
    {
        Phone = phone;
        
        return Result.Success();
    }

    public Result AddFriendship(Friendship friendship)
    {
        if (friendship.UserId != UserId)
            return Result.Failure("Friendship does not belong to the user");
        
        _friendships.Add(friendship);
        
        return Result.Success();
    }

    public Result AddLike(Like like)
    {
        if (like.UserId != UserId)
            return Result.Failure("Like does not belong to the user");
        
        _likes.Add(like);
        
        return Result.Success();
    }
}