using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("mediaTypes")]
[PrimaryKey(nameof(MediaTypeId))]
public class DbMediaType
{
    [Column("media_type_id")]
    public int MediaTypeId { get; set; }
    
    [Column("media_name")]
    public string MediaName { get; set; }
}