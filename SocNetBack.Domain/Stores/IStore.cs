namespace SocNetBack.Domain.Stores;

public interface IStore<TDomainModel, TDbEntity>
{
    Task<TDomainModel> MapToDomainModel(TDbEntity dbEntity);
    Task<TDbEntity> MapToDbEntity(TDomainModel domainModel);
}