using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("friends")]
[PrimaryKey(nameof(UserId), nameof(FriendId))]
public class DbFriend
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("friend_id")]
    public Guid FriendId { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}