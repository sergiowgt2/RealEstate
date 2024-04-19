namespace RealEstate.Service.Interfaces;

public interface IBaseEntityRepository<TEntity>
{
    Task<TEntity> Get(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Add(TEntity newEntity);
    Task Update(TEntity toUpdate);
}