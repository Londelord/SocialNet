using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("postsMedia")]
[PrimaryKey(nameof(PostId), nameof(MediaId))]
public class DbPostMedia
{
    [Column("post_id")]
    public Guid PostId { get; set; }
    
    [Column("media_id")]
    public Guid MediaId { get; set; }
    
    [Column("media_type_id")]
    public int MediaTypeId { get; set; }
    
    [Column("media_url")]
    public string MediaUrl { get; set; }
    
    [Column("position_in_post")]
    public int PositionInPost { get; set; }
}