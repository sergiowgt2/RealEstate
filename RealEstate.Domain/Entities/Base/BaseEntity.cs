using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; set; }
    public EntityStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}