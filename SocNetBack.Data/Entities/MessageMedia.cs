using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("messageMedia")]
[PrimaryKey(nameof(MessageId), nameof(MediaId))]
public class MessageMedia
{
    public MessageMedia(Guid messageId, Guid mediaId, int mediaTypeId, string mediaUrl, int positionInMessage)
    {
        MessageId = messageId;
        MediaId = mediaId;
        MediaTypeId = mediaTypeId;
        MediaUrl = mediaUrl;
        PositionInMessage = positionInMessage;
    }

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