using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Domain.Entities;

public class Landlord: NamedBaseEntity
{
    [MaxLength(14)]
    public string CpfCnpj { get; set; }
    [MaxLength(14)]
    public string CellPhone { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }

    public override void Validate()
    {
        
    }
}