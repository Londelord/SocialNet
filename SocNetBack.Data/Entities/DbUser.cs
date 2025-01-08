using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("users")]
[PrimaryKey(nameof(UserId))]
public class DbUser
{
    public DbUser(Guid userId, string username, string? email, string? phone, string firstName, 
        string lastName, DateTime? birthDate, int genderId, string? profilePictureUrl, 
        string? bio, string? country, string? city, DateTime createdAt, bool verificationStatus)
    {
        UserId = userId;
        Username = username;
        Email = email;
        Phone = phone;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        GenderId = genderId;
        ProfilePictureUrl = profilePictureUrl;
        Bio = bio;
        Country = country;
        City = city;
        CreatedAt = createdAt;
        VerificationStatus = verificationStatus;
    }


    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("user_name")]
    [MaxLength(30)]
    public string Username { get; set; }

    [Column("email")]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Column("phone_number")]
    [MaxLength(20)]
    public string? Phone { get; set; }
    
    [Column("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Column("date_of_birth")]
    public DateTime? BirthDate { get; set; }

    [Column("gender_id")]
    public int GenderId { get; set; }

    [Column("profile_picture_url")]
    public string? ProfilePictureUrl { get; set; }
    
    [Column("bio")]
    [MaxLength(300)]
    public string? Bio { get; set; }
    
    [Column("country")]
    [MaxLength(20)]
    public string? Country { get; set; }

    [Column("city")]
    [MaxLength(20)]
    public string? City { get; set; }
    
    [Column("date_created")]
    public DateTime CreatedAt { get; set; }

    [Column("verification_status")]
    public bool VerificationStatus { get; set; }
}
