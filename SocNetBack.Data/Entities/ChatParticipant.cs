using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("chatParticipants")]
[PrimaryKey(nameof(ChatId), nameof(UserId))]
public class ChatParticipant
{
    public ChatParticipant(Guid chatId, Guid userId, DateTimeOffset joinedAt)
    {
        ChatId = chatId;
        UserId = userId;
        JoinedAt = joinedAt;
    }

    [Column("chat_id")]
    public Guid ChatId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("joined_at")]
    public DateTimeOffset JoinedAt { get; set; }
}