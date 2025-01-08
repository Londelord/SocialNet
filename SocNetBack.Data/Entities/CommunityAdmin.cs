using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("communityAdmins")]
[PrimaryKey(nameof(CommunityId), nameof(AdminId))]
public class CommunityAdmin
{
    public CommunityAdmin(Guid communityId, Guid adminId, JsonDocument permissions)
    {
        CommunityId = communityId;
        AdminId = adminId;
        Permissions = permissions;
    }

    [Column("community_id")]
    public Guid CommunityId { get; set; }
    
    [Column("admin_id")]
    public Guid AdminId { get; set; }
    
    [Column("permissions")]
    public JsonDocument Permissions { get; set; }
}