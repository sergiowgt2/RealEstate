using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class RentalProperty : BaseEntity
{
    public Guid LandLord { get; set; }
    public PropertyTypeEnum PropertyTypeEnum { get; set; }
    public string NickName { get; set; }
    public string Address { get; set; }
    
}