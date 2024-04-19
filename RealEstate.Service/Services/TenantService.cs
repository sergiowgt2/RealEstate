using RealEstate.Domain.Entities;
using RealEstate.Service.Interfaces;
using RealEstate.Service.Model;
using RealEstate.Service.Services.Base;

namespace RealEstate.Service.Services;

public class TenantService : BaseService<Tenant, TenantInsertModel>, ITenantService
{
    public TenantService(IBaseEntityRepository<Tenant> repo) : base(repo)
    {
    }

    public override Tenant AddMigration(TenantInsertModel toAdd)
    {
        var newTenant = new Tenant()
        {
            Id = new Guid(),
            CellPhone = toAdd.CellPhone,
            CNPJ_CPF = toAdd.CpfCnpj,
            Name = toAdd.Name,
            Email = toAdd.Email,
            CreatedAt = DateTime.Now,
            CreatedBy = toAdd.CreatedBy
        };

        return newTenant;
    }
}