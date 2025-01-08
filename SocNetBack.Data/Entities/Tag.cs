using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("tags")]
public class Tag
{
    public Tag(Guid tagId, string tagName)
    {
        TagId = tagId;
        TagName = tagName;
    }

    [Column("tag_id")]
    public Guid TagId { get; set; }
    
    [Column("tag_name")]
    [MaxLength(50)]
    public string TagName { get; set; }
}