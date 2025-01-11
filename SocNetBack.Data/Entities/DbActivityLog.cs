using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("activityLogs")]
[PrimaryKey(nameof(LogId))]
public class DbActivityLog
{
    [Column("log_id")]
    public Guid LogId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("action_type_id")]
    public int ActionTypeId { get; set; }
    
    [Column("details")]
    public string Details { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}