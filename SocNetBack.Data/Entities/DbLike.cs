using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("likes")]
[PrimaryKey(nameof(UserId), nameof(PostId))]
public class DbLike
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("post_id")]
    public Guid PostId { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}