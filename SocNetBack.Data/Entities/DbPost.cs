using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("posts")]
public class DbPost
{
    public DbPost(Guid postId, Guid authorId, DateTimeOffset createdAt, DateTimeOffset? updatedAt,
        string? content, bool isCommunityPost, Guid? communityId)
    {
        PostId = postId;
        AuthorId = authorId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Content = content;
        IsCommunityPost = isCommunityPost;
        CommunityId = communityId;
    }

    [Column("post_id")]
    [Key]
    public Guid PostId { get; set; }
    
    [Column("author_id")]
    public Guid AuthorId { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [Column("content")]
    [MaxLength(15000)]
    public string? Content { get; set; }
    
    [Column("is_community_post")]
    public bool IsCommunityPost { get; set; }
    
    [Column("community_id")]
    public Guid? CommunityId { get; set; }
}