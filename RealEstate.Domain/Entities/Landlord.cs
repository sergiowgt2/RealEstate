using RealEstate.Domain.Entities.Base;

namespace RealEstate.Domain.Entities;

public class Landlord: BaseEntity
{
    public string CpfCnpj { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
}