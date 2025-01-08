using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("postTagMapping")]
[PrimaryKey(nameof(PostId), nameof(TagId))]
public class PostTagMapping
{
    public PostTagMapping(Guid postId, Guid tagId)
    {
        PostId = postId;
        TagId = tagId;
    }

    [Column("post_id")]
    public Guid PostId { get; set; }
    
    [Column("tag_id")]
    public Guid TagId { get; set; }
}