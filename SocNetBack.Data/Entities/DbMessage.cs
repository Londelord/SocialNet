using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("messages")]
[PrimaryKey(nameof(MessageId))]
public class DbMessage
{
    [Column("message_id")]
    public Guid MessageId { get; set; }
    
    [Column("chat_id")]
    public Guid ChatId { get; set; }
    
    [Column("sender_id")]
    public Guid SenderId { get; set; }
    
    [Column("content")]
    public string Content { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}