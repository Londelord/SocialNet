using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("views")]
[PrimaryKey(nameof(UserId), nameof(PostId))]
public class DbView
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("post_id")]
    public Guid PostId { get; set; }
}