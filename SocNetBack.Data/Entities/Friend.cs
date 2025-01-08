using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("friends")]
[PrimaryKey(nameof(UserId), nameof(FriendId))]
public class Friend
{
    public Friend(Guid userId, Guid friendId, int statusId, DateTimeOffset createdAt)
    {
        UserId = userId;
        FriendId = friendId;
        StatusId = statusId;
        CreatedAt = createdAt;
    }

    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("friend_id")]
    public Guid FriendId { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}