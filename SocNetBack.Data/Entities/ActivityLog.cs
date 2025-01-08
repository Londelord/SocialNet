using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("activityLogs")]
public class ActivityLog
{
    public ActivityLog(Guid logId, Guid userId, int actionTypeId, string details, DateTimeOffset createdAt)
    {
        LogId = logId;
        UserId = userId;
        ActionTypeId = actionTypeId;
        Details = details;
        CreatedAt = createdAt;
    }

    [Column("log_id")]
    [Key]
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