using RealEstate.Domain.Entities;

namespace RealEstate.Service.Interfaces;

public interface ILandLordRepository : INamedBaseEntityRepository<Landlord>
{
    Task<Landlord> GetByCpfCnpj(string cpfCnpj,  Guid? excId);
    Task<Landlord> GetByEmail(string email,  Guid? excId);
    Task<Landlord> GetByCellPhone(string cellPhone,  Guid? excId);
}