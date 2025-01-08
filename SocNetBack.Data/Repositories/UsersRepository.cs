using CSharpFunctionalExtensions;
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
        DbUser dbUser = await _dbContext.Users.FindAsync(userId) ??
                        throw new NullReferenceException("User not found");

        User user = MapToDomainModel(dbUser);
        
        return user;
    }


    public User MapToDomainModel(DbUser dbUser)
    {
        var email = dbUser.Email is null ? null : Email.Create(dbUser.Email).Value;
        var phone = dbUser.Phone is null ? null : Phone.Create(dbUser.Phone).Value;
        
        var dbGender = _dbContext.Genders.Find(dbUser.GenderId) ??
                            throw new NullReferenceException("Gender not found");
        
        var gender = Gender.Create(dbGender.GenderName).Value;

        var address = dbUser.Country is null ? null : Address.Create("", "", "").Value;
        
        User user = User.Create(
            dbUser.UserId,
            dbUser.Username,
            email,
            phone,
            dbUser.FirstName,
            dbUser.LastName,
            dbUser.BirthDate,
            gender,
            dbUser.ProfilePictureUrl,
            dbUser.Bio,
            address,
            dbUser.VerificationStatus
        ).Value;
        
        return user;
    }

    public DbUser MapToDbEntity(User domainModel)
    {
        throw new NotImplementedException();
    }
}