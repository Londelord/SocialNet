using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("communitySubscribers")]
[PrimaryKey(nameof(CommunityId), nameof(UserId))]
public class CommunitySubscriber
{
    public CommunitySubscriber(Guid communityId, Guid userId, DateTimeOffset subscriptionDate)
    {
        CommunityId = communityId;
        UserId = userId;
        SubscriptionDate = subscriptionDate;
    }

    [Column("community_id")]
    public Guid CommunityId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("subscription_date")]
    public DateTimeOffset SubscriptionDate { get; set; }
}