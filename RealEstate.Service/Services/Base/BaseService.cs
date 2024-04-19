using RealEstate.Domain.Entities.Base;
using RealEstate.Service.Interfaces;
using RealEstate.Service.Model.Base;

namespace RealEstate.Service.Services.Base;
   
public class BaseService<TBaseEntity, TBaseModel>: IBaseService<TBaseEntity, TBaseModel>  
    where TBaseEntity :  BaseEntity
    where TBaseModel :  BaseModel
{
    protected IBaseEntityRepository<TBaseEntity> repo;
    
    public BaseService(IBaseEntityRepository<TBaseEntity> repo)
    {
        this.repo = repo;
    }

    public virtual TBaseEntity AddMigration(TBaseModel toAdd)
    {
        return null;
    }
    
    public virtual async Task Add(TBaseModel toAdd)
    {
        var converted = AddMigration(toAdd);
        await repo.Add(converted);
    }
}