using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("users")]
[PrimaryKey(nameof(UserId))]
public class DbUser
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("user_name")]
    public string Username { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone_number")]
    public string? Phone { get; set; }
    
    [Column("first_name")]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    public string LastName { get; set; }

    [Column("date_of_birth")]
    public DateTime? BirthDate { get; set; }

    [Column("gender_id")]
    public int GenderId { get; set; }

    [Column("profile_picture_url")]
    public string? ProfilePictureUrl { get; set; }
    
    [Column("bio")]
    public string? Bio { get; set; }
    
    [Column("country")]
    public string? Country { get; set; }
    
    [Column("region")]
    public string? Region { get; set; }

    [Column("city")]
    public string? City { get; set; }
    
    [Column("date_created")]
    public DateTime CreatedAt { get; set; }

    [Column("verification_status")]
    public bool VerificationStatus { get; set; }
    
    public DbGender? Gender { get; set; }
    public ICollection<DbFriend> Friends { get; set; } = new List<DbFriend>();
    public ICollection<DbLike> Likes { get; set; } = new List<DbLike>();
}
