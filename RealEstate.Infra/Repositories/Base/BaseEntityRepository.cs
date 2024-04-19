using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Enums;
using RealEstate.Service.Interfaces;
using RealEstate.Infra.Database;
    
namespace RealEstate.Infra.Repositories.Base;

public class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity
{
    protected ApplicationDbContext Context;

    public BaseEntityRepository(ApplicationDbContext db)
    {
        Context = db;
    }

    protected async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> condition) =>
        await Context.Set<TEntity>().FirstOrDefaultAsync(condition);

    protected async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> condition) =>
        await Context.Set<TEntity>().Where(condition).ToListAsync();
    
    public async Task<TEntity> Get(Guid id) => 
        await FirstAsync(x => x.Id == id && x.Status != EntityStatusEnum.Deleted);

    public async Task<IEnumerable<TEntity>> GetAll() =>
        await ListAsync(x => x.Status != EntityStatusEnum.Deleted);

    public async Task Add(TEntity newEntity)
    {
        Context.Set<TEntity>().Add(newEntity);
        await Context.SaveChangesAsync();
    }

    public async Task Update(TEntity toUpdate)
    {
        Context.Entry(toUpdate).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}