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
        Expression<Func<TEntity, bool>> filter;
        if (excId == null)
            filter = x => x.Name == name && x.Status != EntityStatusEnum.Deleted;
        else 
            filter = x => x.Name == name && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(filter);
    }
}

