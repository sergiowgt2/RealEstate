using RealEstate.Domain.Entities;
using RealEstate.Service.Model;
using RealEstate.Service.Services.Base;

namespace RealEstate.Service.Services;

public interface ITenantService : IBaseService<Tenant, TenantInsertModel>
{
    
}