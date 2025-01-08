using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("postsMedia")]
[PrimaryKey(nameof(PostId), nameof(MediaId))]
public class PostMedia
{
    public PostMedia(Guid postId, Guid mediaId, int mediaTypeId, string mediaUrl, int positionInPost)
    {
        PostId = postId;
        MediaId = mediaId;
        MediaTypeId = mediaTypeId;
        MediaUrl = mediaUrl;
        PositionInPost = positionInPost;
    }

    [Column("post_id")]
    public Guid PostId { get; set; }
    
    [Column("media_id")]
    public Guid MediaId { get; set; }
    
    [Column("media_type_id")]
    public int MediaTypeId { get; set; }
    
    [Column("media_url")]
    public string MediaUrl { get; set; }
    
    [Column("position_in_post")]
    [Range(0, 9)]
    public int PositionInPost { get; set; }
}