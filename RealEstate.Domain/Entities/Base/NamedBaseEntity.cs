using System.ComponentModel.DataAnnotations;

namespace RealEstate.Domain.Entities.Base;

public class NamedBaseEntity : BaseEntity
{
    [MaxLength(100)]
    public string Name { get; set; }
}