using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("communitySubscribers")]
[PrimaryKey(nameof(CommunityId), nameof(UserId))]
public class DbCommunitySubscriber
{
    [Column("community_id")]
    public Guid CommunityId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("subscription_date")]
    public DateTimeOffset SubscriptionDate { get; set; }
}