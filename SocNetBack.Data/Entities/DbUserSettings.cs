using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("usersSettings")]
[PrimaryKey(nameof(UserId))]
public class DbUserSettings
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("privacy_preferences")]
    public JsonDocument PrivacyPreferences { get; set; }
    
    [Column("language_preferences")]
    public string LanguagePreferences { get; set; }
    
    [Column("notification_preferences")]
    public JsonDocument NotificationPreferences { get; set; }
    
    [Column("appearance_preferences")]
    public JsonDocument AppearancePreferences { get; set; }
}