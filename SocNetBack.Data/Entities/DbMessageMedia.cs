using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("messageMedia")]
[PrimaryKey(nameof(MessageId), nameof(MediaId))]
public class DbMessageMedia
{
    [Column("message_id")]
    public Guid MessageId { get; set; }
    
    [Column("media_id")]
    public Guid MediaId { get; set; }
    
    [Column("media_type_id")]
    public int MediaTypeId { get; set; }
    
    [Column("media_url")]
    public string MediaUrl { get; set; }
    
    [Column("position_in_message")]
    public int PositionInMessage { get; set; }
}