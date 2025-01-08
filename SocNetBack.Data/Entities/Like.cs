using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("likes")]
[PrimaryKey(nameof(UserId), nameof(PostId))]
public class Like
{
    public Like(Guid userId, Guid postId)
    {
        UserId = userId;
        PostId = postId;
    }

    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("post_id")]
    public Guid PostId { get; set; }
}