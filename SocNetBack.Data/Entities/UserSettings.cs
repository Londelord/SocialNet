using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SocNetBack.Domain.Models;

[Table("usersSettings")]
public class UserSettings
{
    public UserSettings(Guid userId, JsonDocument privacyPreferences, string languagePreferences, 
        JsonDocument notificationPreferences, JsonDocument appearancePreferences)
    {
        UserId = userId;
        PrivacyPreferences = privacyPreferences;
        LanguagePreferences = languagePreferences;
        NotificationPreferences = notificationPreferences;
        AppearancePreferences = appearancePreferences;
    }

    [Column("user_id")]
    [Key]
    public Guid UserId { get; set; }
    
    [Column("privacy_preferences")]
    public JsonDocument PrivacyPreferences { get; set; }
    
    [Column("language_preferences")]
    [MaxLength(20)]
    public string LanguagePreferences { get; set; }
    
    [Column("notification_preferences")]
    public JsonDocument NotificationPreferences { get; set; }
    
    [Column("appearance_preferences")]
    public JsonDocument AppearancePreferences { get; set; }
}