using CSharpFunctionalExtensions;
using SocNetBack.Domain.ValueObjects;

namespace SocNetBack.Domain.Models;

public class User
{
    private User(Guid userId, string username, Email? email, Phone? phone, string firstName, 
        string lastName, DateTime? birthDate, Gender gender, string? profilePictureUrl, 
        string? bio, Address? address, DateTime createdAt, bool verificationStatus)
    {
        UserId = userId;
        Username = username;
        Email = email;
        Phone = phone;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Gender = gender;
        ProfilePictureUrl = profilePictureUrl;
        Bio = bio;
        Address = address;
        CreatedAt = createdAt;
        VerificationStatus = verificationStatus;
    }
    
    public Guid UserId { get; }
    public string Username { get; private set; }
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public string? ProfilePictureUrl { get; }
    public string? Bio { get; }
    public Address? Address { get; private set; }
    public DateTime CreatedAt { get; }
    public bool VerificationStatus { get; }
    
    #region Validation constants

    public const int MIN_USERNAME_LENGTH = 5;
    public const int MAX_USERNAME_LENGTH = 30;
    
    
    #endregion

     public static Result<User> Create(Guid userId, string username, Email? email, Phone? phone, string firstName,
        string lastName, DateTime? birthDate, Gender gender, string? profilePictureUrl,
        string? bio, Address? address, bool verificationStatus)
    {
        if (username.Length > MAX_USERNAME_LENGTH || username.Length < MIN_USERNAME_LENGTH) 
            return Result.Failure<User>("Username must be between 5 and 30 characters");
        
        if (email is null && phone is null)
            return Result.Failure<User>("Email or phone are required");
        
        if (birthDate is not null && birthDate > DateTime.Today)
            return Result.Failure<User>("Birth date cannot be in the future");

        var user = new User(userId, username, email, phone, firstName, lastName, birthDate,
            gender, profilePictureUrl, bio, address, DateTime.Now, verificationStatus);
        
        return Result.Success(user);
    }

    public Result ChangeEmail(Email email)
    {
        Email = email;
        
        return Result.Success();
    }
}