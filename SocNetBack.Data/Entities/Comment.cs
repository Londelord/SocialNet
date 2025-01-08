using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("comments")]
public class Comment
{
    public Comment(Guid commentId, Guid postId, Guid authorId, 
        string content, DateTimeOffset createdAt, DateTimeOffset? updatedAt, 
        bool isCommunityComment, Guid? communityId)
    {
        CommentId = commentId;
        PostId = postId;
        AuthorId = authorId;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsCommunityComment = isCommunityComment;
        CommunityId = communityId;
    }

    [Column("comment_id")]
    public Guid CommentId { get; set; }
    
    [Column("post_id")]
    public Guid PostId { get; set; }
    
    [Column("author_id")]
    public Guid AuthorId { get; set; }
    
    [Column("content")]
    [MaxLength(500)]
    public string Content { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [Column("is_community_comment")]
    public bool IsCommunityComment { get; set; }
    
    [Column("community_id")]
    public Guid? CommunityId { get; set; }
}