using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("userPasswords")]
public class UserPassword
{

    public UserPassword(Guid userId, string passwordHash, string salt)
    {
        UserId = userId;
        PasswordHash = passwordHash;
        Salt = salt;
    }
    
    [Column("user_id")]
    [Key]
    public Guid UserId { get; set; }
    
    [Column("password_hash")]
    [MaxLength(255)]
    public string PasswordHash { get; set; }
    
    [Column("salt")]
    [MaxLength(255)]
    public string Salt { get; set; }
}