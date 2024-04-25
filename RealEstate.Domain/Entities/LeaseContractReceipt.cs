using RealEstate.Domain.Entities.Base;

namespace RealEstate.Domain.Entities;

public class LeaseContractReceipt: BaseEntity
{
    public Guid LeaseContractProvisionId { get; set; }
    public DateOnly PayDay { get; set; }
    public Decimal Value  { get; set; }
}