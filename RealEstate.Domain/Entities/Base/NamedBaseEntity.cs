using System.ComponentModel.DataAnnotations;
using System.Formats.Tar;
using Microsoft.Extensions.Options;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Domain.Entities.Base;

public class NamedBaseEntity : BaseEntity
{
    [MaxLength(100)]
    public string Name { get; set; }


    public virtual void teste()
    {
        
    }
    public override void Validate()
    {
        base.Validate();
        DomainException.When(String.IsNullOrWhiteSpace(Name), "Name cannot be empty!");
    }
}