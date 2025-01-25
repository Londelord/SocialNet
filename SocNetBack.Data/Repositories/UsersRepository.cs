using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SocNetBack.Data.DataAccess;
using SocNetBack.Data.Entities;
using SocNetBack.Domain.Stores;
using SocNetBack.Domain.Models;
using SocNetBack.Domain.ValueObjects;


namespace SocNetBack.Data.Repositories;

public class UsersRepository : IUserStore, IStore<User, DbUser>
{
    private readonly SocNetDbContext _dbContext;

    public UsersRepository(SocNetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetById(Guid userId)
    {
        DbUser? dbUser = await _dbContext.Users
            .Include(u => u.Gender)
            .Include(u => u.Friends)
            .Include(u => u.Likes)
            .FirstOrDefaultAsync(u => u.UserId == userId);
        
        if (dbUser == null)
        {
            return null;
        }
        
        User user = await MapToDomainModel(dbUser);
        
        return user;
    }
    
    public Task<User> MapToDomainModel(DbUser dbUser)
    {
        var email = dbUser.Email is null ? null : Email.Create(dbUser.Email).Value;
        var phone = dbUser.Phone is null ? null : Phone.Create(dbUser.Phone).Value;
        
        var gender = Gender.Create(dbUser.Gender?.GenderName ?? throw new NullReferenceException("Gender not found")).Value;
        
        var profileImage = dbUser.ProfilePictureUrl is null ? null : 
            ImageFile.Create(dbUser.ProfilePictureUrl).Value;

        var address = dbUser.Country is null ? null : Address.Create("", "", "").Value;
        
        var friends = dbUser.Friends
            .Select(dbFriend =>
                Friendship.Create(dbFriend.UserId, dbFriend.FriendId, dbFriend.CreatedAt).Value)
            .ToList();

        var likes = dbUser.Likes
            .Select(dbLike => Like.Create(dbLike.UserId, dbLike.PostId, dbLike.CreatedAt).Value)
            .ToList();
        
        var user = User.Create(
            dbUser.UserId,
            dbUser.Username,
            email,
            phone,
            dbUser.FirstName,
            dbUser.LastName,
            dbUser.BirthDate,
            gender,
            profileImage,
            dbUser.Bio,
            address,
            dbUser.CreatedAt,
            dbUser.VerificationStatus,
            friends,
            likes
        ).Value;
        
        return Task.FromResult(user);
    }

    public async Task<Result> RegisterUser(User user, string hashedPassword)
    {
        var dbUser = await MapToDbEntity(user);
        
        await _dbContext.Users.AddAsync(dbUser);
        await _dbContext.SaveChangesAsync();

        var dbPasswordUser = new DbUserPassword { UserId = dbUser.UserId, PasswordHash = hashedPassword, Salt = "" };
        await _dbContext.UserPasswords.AddAsync(dbPasswordUser);
        await _dbContext.SaveChangesAsync();
        
        return Result.Success();
    }

    public async Task<Result> IsUserExist(string? email, string? username)
    {
        if (email is not null)
        {
            var newEmailResult = Email.Create(email);
            if (newEmailResult.IsFailure)
                return Result.Failure(newEmailResult.Error);
            
            var dbUserEmail = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == newEmailResult.Value!.Value);
            
            if (dbUserEmail != null)
                return Result.Failure("User with this email already exists");
        }

        if (username is not null)
        {
            var dbUserUsername = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if(dbUserUsername != null)
                return Result.Failure("User with this username already exists");
        }
        
        return Result.Success();
    }

    public async Task<User?> GetByEmail(string email)
    {
        var dbUser = await _dbContext.Users
            .Include(u => u.Gender)
            .FirstOrDefaultAsync(u => u.Email == email);
        if (dbUser == null)
            return null;
        return await MapToDomainModel(dbUser);
    }

    public async Task<string> GetPasswordHash(Guid? userId)
    {
        var dbUserPassword = await _dbContext.UserPasswords
            .FirstOrDefaultAsync(u => u.UserId == userId);
        
        if (dbUserPassword is null)
            throw new NullReferenceException("User not found");
        
        return dbUserPassword.PasswordHash;
    }

    public async Task<Result> WriteAccessToken(User user, string token)
    {
        var dbSession = new DbUserSession
        {
            SessionId = Guid.NewGuid(),
            UserId = user.UserId,
            AccessToken = token,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddHours(12),
            UserAgent = null,
            IpAddress = null
        };
        
        await _dbContext.UserSessions.AddAsync(dbSession);
        await _dbContext.SaveChangesAsync();
        return Result.Success();
    }


    public async Task<DbUser> MapToDbEntity(User domainModel)
    {
        var gender = await _dbContext.Genders.Where(g => 
                         g.GenderName.ToLower() == domainModel.Gender.Value.ToLower()).FirstOrDefaultAsync() ?? 
                     throw new NullReferenceException("Gender not found");
        
        var dbUser = new DbUser
        {
            UserId = domainModel.UserId,
            Username = domainModel.Username,
            Email = domainModel.Email?.Value,
            Phone = domainModel.Phone?.Value,
            FirstName = domainModel.FirstName,
            LastName = domainModel.LastName,
            BirthDate = domainModel.BirthDate,
            GenderId = gender.GenderId,
            ProfilePictureUrl = domainModel.ProfilePicture?.Path,
            Bio = null,
            Country = domainModel.Address?.Country,
            Region = domainModel.Address?.Region,
            City = domainModel.Address?.City,
            CreatedAt = domainModel.CreatedAt,
            VerificationStatus = domainModel.VerificationStatus
        };

        return dbUser;
    }
}