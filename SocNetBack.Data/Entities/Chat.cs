using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("chats")]
public class Chat
{
    public Chat(Guid chatId, bool isGroupChat, DateTime createdAt, string? title, string? description)
    {
        ChatId = chatId;
        IsGroupChat = isGroupChat;
        CreatedAt = createdAt;
        Title = title;
        Description = description;
    }


    [Column("chat_id")]
    [Key]
    public Guid ChatId { get; set; }
    
    [Column("is_group_chat")]
    public bool IsGroupChat { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("title")]
    [MaxLength(100)]
    public string? Title { get; set; }
    
    [Column("description")]
    [MaxLength(1000)]
    public string? Description { get; set; }
}