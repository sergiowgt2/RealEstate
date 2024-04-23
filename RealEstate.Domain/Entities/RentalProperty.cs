using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Exceptions;

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

    public override void Validate()
    {
        base.Validate();
        DomainException.When(String.IsNullOrWhiteSpace(NickName), "NickName must not be empty!");
        DomainException.When(String.IsNullOrWhiteSpace(Address), "Address must not be empty!");
        
    }
}