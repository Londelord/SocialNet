using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("chatParticipants")]
[PrimaryKey(nameof(ChatId), nameof(UserId))]
public class DbChatParticipant
{
    [Column("chat_id")]
    public Guid ChatId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("joined_at")]
    public DateTimeOffset JoinedAt { get; set; }
}