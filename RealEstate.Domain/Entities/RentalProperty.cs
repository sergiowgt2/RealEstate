using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class RentalProperty : BaseEntity
{
    public Guid LandlordId { get; set; }
    public Landlord Landlord { get; set; }
    
    public PropertyTypeEnum PropertyTypeEnum { get; set; }
    [MaxLength(30)]
    public string NickName { get; set; }
    [MaxLength(150)]
    public string Address { get; set; }
    
    public ICollection<LeaseContract> LeaseContracts { get; set; }
}