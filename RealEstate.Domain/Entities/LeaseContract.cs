using System.Runtime.InteropServices.JavaScript;
using RealEstate.Domain.Entities.Base;

namespace RealEstate.Domain.Entities;

public class LeaseContract : BaseEntity
{
    public Guid RentalPropertyId { get; set; }
    public RentalProperty RentalProperty { get; set; }
    
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public DateOnly StartDate { get; set; }
    public DateOnly SignDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public int PaymentDueDate { get; set; }
    public float RentValue  { get; set; }
    public float AdministrationFee { get; set; }
}