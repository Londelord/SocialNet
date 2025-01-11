using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("communities")]
[PrimaryKey(nameof(CommunityId))]
public class DbCommunity
{
    [Column("community_id")]
    public Guid CommunityId { get; set; }
    
    [Column("community_name")]
    public string CommunityName { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("community_picture_url")]
    public string? CommunityPictureUrl { get; set; }
    
    [Column("date_created")]
    public DateTime DateCreated { get; set; }
    
    [Column("creator_id")]
    public Guid CreatorId { get; set; }
}