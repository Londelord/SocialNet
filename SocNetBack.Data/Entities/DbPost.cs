using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("posts")]
[PrimaryKey(nameof(PostId))]
public class DbPost
{
    [Column("post_id")]
    public Guid PostId { get; set; }
    
    [Column("author_id")]
    public Guid AuthorId { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [Column("content")]
    public string? Content { get; set; }
    
    [Column("is_community_post")]
    public bool IsCommunityPost { get; set; }
    
    [Column("community_id")]
    public Guid? CommunityId { get; set; }
}