using RealEstate.Domain.Entities.Base;

namespace RealEstate.Service.Interfaces;

public interface INamedBaseEntityRepository<TEntity>: IBaseEntityRepository<TEntity> where TEntity : NamedBaseEntity
{
    Task<TEntity> GetByName(string name,  Guid? excId);
}