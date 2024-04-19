using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Enums;
using RealEstate.Infra.Database;
using RealEstate.Service.Interfaces;

namespace RealEstate.Infra.Repositories.Base;

public class NamedBaseEntityRepository<TEntity> : BaseEntityRepository<TEntity>, INamedBaseEntityRepository<TEntity> where TEntity : NamedBaseEntity 
{
    public NamedBaseEntityRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<TEntity> GetByName(string name, Guid? excId = null)
    {
        Expression<Func<TEntity, bool>> condition = x => x.Name == name && x.Status != EntityStatusEnum.Deleted;
        
        if (excId == null)
            condition = x => condition.Compile()(x) && x.Id != excId;
        
        return await Context.Set<TEntity>().FirstAsync(condition);
    }
}