using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("messages")]
public class Message
{
    public Message(Guid messageId, Guid chatId, Guid senderId, string content, DateTimeOffset createdAt)
    {
        MessageId = messageId;
        ChatId = chatId;
        SenderId = senderId;
        Content = content;
        CreatedAt = createdAt;
    }

    [Column("message_id")]
    public Guid MessageId { get; set; }
    
    [Column("chat_id")]
    public Guid ChatId { get; set; }
    
    [Column("sender_id")]
    public Guid SenderId { get; set; }
    
    [Column("content")]
    [MaxLength(1000)]
    public string Content { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}