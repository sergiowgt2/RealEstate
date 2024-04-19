using RealEstate.Domain.Entities.Base;
using RealEstate.Service.Model.Base;

namespace RealEstate.Service.Services.Base;


public interface IBaseService<TBaseEntity, TBaseModel>
{
    TBaseEntity AddMigration(TBaseModel toAdd);
}