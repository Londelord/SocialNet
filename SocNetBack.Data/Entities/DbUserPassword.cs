using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("userPasswords")]
[PrimaryKey(nameof(UserId))]
public class DbUserPassword
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("password_hash")]
    public string PasswordHash { get; set; }
    
    [Column("salt")]
    public string Salt { get; set; }
}