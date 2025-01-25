using Microsoft.EntityFrameworkCore;
using SocNetBack.Data.Entities;
using SocNetBack.Domain.Models;

namespace SocNetBack.Data.DataAccess;

public class SocNetDbContext(DbContextOptions<SocNetDbContext> options) : DbContext(options)
{
    public DbSet<DbUser> Users => Set<DbUser>();
    public DbSet<DbActionTypes> ActionTypes => Set<DbActionTypes>();
    public DbSet<DbActivityLog> ActivityLogs => Set<DbActivityLog>();
    public DbSet<DbChat> Chats => Set<DbChat>();
    public DbSet<DbChatParticipant> ChatParticipants => Set<DbChatParticipant>();
    public DbSet<DbComment> Comments => Set<DbComment>();
    public DbSet<DbCommunity> Communities => Set<DbCommunity>();
    public DbSet<DbCommunityAdmin> CommunityAdmins => Set<DbCommunityAdmin>();
    public DbSet<DbCommunitySubscriber> CommunitySubscribers => Set<DbCommunitySubscriber>();
    public DbSet<DbFriend> Friends => Set<DbFriend>();
    public DbSet<DbGender> Genders => Set<DbGender>();
    public DbSet<DbLike> Likes => Set<DbLike>();
    public DbSet<DbMediaType> MediaTypes => Set<DbMediaType>();
    public DbSet<DbMessage> Messages => Set<DbMessage>();
    public DbSet<DbMessageMedia> MessageMedia => Set<DbMessageMedia>();
    public DbSet<DbPost> Posts => Set<DbPost>();
    public DbSet<DbPostMedia> PostMedia => Set<DbPostMedia>();
    public DbSet<DbStatus> Statuses => Set<DbStatus>();
    public DbSet<DbUserSettings> UserSettings => Set<DbUserSettings>();
    public DbSet<DbUserPassword> UserPasswords => Set<DbUserPassword>();
    public DbSet<DbUserSession> UserSessions => Set<DbUserSession>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>()
            .HasMany(u => u.Friends)
            .WithOne()
            .HasForeignKey(f => f.UserId); // Связь по UserId

        modelBuilder.Entity<DbUser>()
            .HasMany(u => u.Likes)
            .WithOne()
            .HasForeignKey(l => l.UserId); // Связь по UserId
        
        modelBuilder.Entity<DbUser>()
            .HasOne(u => u.Gender)
            .WithMany() // Если у DbGender нет навигационного свойства на пользователей
            .HasForeignKey(u => u.GenderId);

        base.OnModelCreating(modelBuilder);
    }
}