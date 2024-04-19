using RealEstate.Domain.Entities;
using RealEstate.Domain.Entities.Base;
using RealEstate.Service.Interfaces;
using RealEstate.Service.Model;
using RealEstate.Service.Services.Base;

namespace RealEstate.Service.Services;

public class LandLordService : BaseService<Landlord, LandLordInsertModel>, ILandLordService
{
    public LandLordService(IBaseEntityRepository<Landlord> repo) : base(repo)
    {
    }

    public override Landlord AddMigration(LandLordInsertModel toAdd)
    {
        var newLandLord = new Landlord()
        {
            Id = new Guid(),
            CellPhone = toAdd.CellPhone,
            CpfCnpj = toAdd.CpfCnpj,
            Name = toAdd.Name,
            Email = toAdd.Email,
            CreatedAt = DateTime.Now,
            CreatedBy = toAdd.CreatedBy
        };

        return newLandLord;
    }
}