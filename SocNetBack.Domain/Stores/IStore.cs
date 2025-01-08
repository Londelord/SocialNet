namespace SocNetBack.Domain.Stores;

public interface IStore<TDomainModel, TDbEntity>
{
    TDomainModel MapToDomainModel(TDbEntity dbEntity);
    TDbEntity MapToDbEntity(TDomainModel domainModel);
}