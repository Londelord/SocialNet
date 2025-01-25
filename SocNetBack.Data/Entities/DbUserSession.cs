using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("userSessions")]
[PrimaryKey(nameof(SessionId))]
public class DbUserSession
{
    [Column("session_id")]
    public Guid SessionId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("access_token")]
    public string AccessToken { get; set; }
    
    [Column("ip_address")]
    public string? IpAddress { get; set; }
    
    [Column("user_agent")]
    public string? UserAgent { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }
}