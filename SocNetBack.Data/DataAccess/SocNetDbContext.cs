using Microsoft.EntityFrameworkCore;
using SocNetBack.Data.Entities;
using SocNetBack.Domain.Models;

namespace SocNetBack.Data.DataAccess;

public class SocNetDbContext(DbContextOptions<SocNetDbContext> options) : DbContext(options)
{
    public DbSet<DbUser> Users => Set<DbUser>();
    public DbSet<ActionTypes> ActionTypes => Set<ActionTypes>();
    public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();
    public DbSet<Chat> Chats => Set<Chat>();
    public DbSet<ChatParticipant> ChatParticipants => Set<ChatParticipant>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Community> Communities => Set<Community>();
    public DbSet<CommunityAdmin> CommunityAdmins => Set<CommunityAdmin>();
    public DbSet<CommunitySubscriber> CommunitySubscribers => Set<CommunitySubscriber>();
    public DbSet<Friend> Friends => Set<Friend>();
    public DbSet<DbGender> Genders => Set<DbGender>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<MediaType> MediaTypes => Set<MediaType>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<MessageMedia> MessageMedia => Set<MessageMedia>();
    public DbSet<DbPost> Posts => Set<DbPost>();
    public DbSet<PostMedia> PostMedia => Set<PostMedia>();
    public DbSet<PostTagMapping> PostTagMappings => Set<PostTagMapping>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();
    public DbSet<UserPassword> UserPasswords => Set<UserPassword>();
}