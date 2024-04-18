using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; set; }
    public EntityStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    [MaxLength(100)]
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [MaxLength(100)]
    public string? UpdatedBy { get; set; }

    public virtual void Validate()
    {
        DomainException.When(String.IsNullOrWhiteSpace(CreatedBy), "Created By cannot be empty");
        if (UpdatedAt != null) DomainException.When(String.IsNullOrWhiteSpace(UpdatedBy), "Updated By cannot be empty");
        if (UpdatedBy != null) DomainException.When(UpdatedAt == null, "Updated At cannot be empty");
    }
}