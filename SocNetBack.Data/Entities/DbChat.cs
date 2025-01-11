using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("chats")]
[PrimaryKey(nameof(ChatId))]
public class DbChat
{
    [Column("chat_id")]
    public Guid ChatId { get; set; }
    
    [Column("is_group_chat")]
    public bool IsGroupChat { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("title")]
    public string? Title { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
}