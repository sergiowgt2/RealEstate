using RealEstate.Domain.Entities.Base;

namespace RealEstate.Domain.Entities;

public class LeaseContractProvision : BaseEntity
{
    public Guid LeaseContractId { get; set; }
    public int Number { get; set; }
    public DateOnly DueDate { get; set; }
    public Decimal Value  { get; set; }
}