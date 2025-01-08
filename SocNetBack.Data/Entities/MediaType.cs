using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("mediaTypes")]
public class MediaType
{
    public MediaType(int mediaTypeId, string mediaName)
    {
        MediaTypeId = mediaTypeId;
        MediaName = mediaName;
    }

    [Column("media_type_id")]
    public int MediaTypeId { get; set; }
    
    [Column("media_name")]
    [MaxLength(20)]
    public string MediaName { get; set; }
}