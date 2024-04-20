using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Validators;

namespace RealEstate.Domain.Entities;

public class Landlord: NamedBaseEntity
{
    [MaxLength(14)]
    public string CnpjCpf { get; set; }
    [MaxLength(14)]
    public string CellPhone { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    
    public ICollection<RentalProperty> RentalProperties { get; set; }

    public override void Validate()
    {
        base.Validate();
        DomainException.When(String.IsNullOrWhiteSpace(CnpjCpf), "CPF/CNPJ cannot be empty!");
        DomainException.When((CpfCnpjValidador.Validate(CnpjCpf) != true), "CPF/CNPJ is invalid!");
        DomainException.When((CellphoneValidator.Validate(CellPhone) != true), "Cellphone is invalid!");
        DomainException.When((EmailValidador.Validate(Email) != true), "Email is invalid!");
        
    }
}