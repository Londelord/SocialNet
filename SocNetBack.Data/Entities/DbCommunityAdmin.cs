using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("communityAdmins")]
[PrimaryKey(nameof(CommunityId), nameof(AdminId))]
public class DbCommunityAdmin
{
    [Column("community_id")]
    public Guid CommunityId { get; set; }
    
    [Column("admin_id")]
    public Guid AdminId { get; set; }
    
    [Column("permissions")]
    public JsonDocument Permissions { get; set; }
}