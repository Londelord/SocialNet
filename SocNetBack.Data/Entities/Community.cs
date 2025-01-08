using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("communities")]
public class Community
{
    public Community(Guid communityId, string communityName, string title, 
        string? description, string? communityPictureUrl, DateTime dateCreated, Guid creatorId)
    {
        CommunityId = communityId;
        CommunityName = communityName;
        Title = title;
        Description = description;
        CommunityPictureUrl = communityPictureUrl;
        DateCreated = dateCreated;
        CreatorId = creatorId;
    }


    [Column("community_id")]
    public Guid CommunityId { get; set; }
    
    [Column("community_name")]
    [MaxLength(30)]
    public string CommunityName { get; set; }
    
    [Column("title")]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Column("description")]
    [MaxLength(3000)]
    public string? Description { get; set; }
    
    [Column("community_picture_url")]
    public string? CommunityPictureUrl { get; set; }
    
    [Column("date_created")]
    public DateTime DateCreated { get; set; }
    
    [Column("creator_id")]
    public Guid CreatorId { get; set; }
}