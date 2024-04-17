using RealEstate.Domain.Entities.Base;

namespace RealEstate.Domain.Entities;

public class Tenant : NamedBaseEntity
{
    public string CNPJ_CPF { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
}