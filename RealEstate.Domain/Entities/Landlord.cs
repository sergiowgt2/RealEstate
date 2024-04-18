using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Validators;

namespace RealEstate.Domain.Entities;

public class Landlord: BaseEntity
{
    [MaxLength(14)]
    public string CpfCnpj { get; set; }
    [MaxLength(14)]
    public string CellPhone { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }

    public override void Validate()
    {
        base.Validate();
        DomainException.When(String.IsNullOrWhiteSpace(CpfCnpj), "CPF/CNPJ cannot be empty!");
        DomainException.When((CpfCnpjValidador.Validate(CpfCnpj) != true), "CPF/CNPJ is invalid!");
        DomainException.When((CellphoneValidator.Validate(CellPhone) != true), "Cellphone is invalid!");
        DomainException.When((EmailValidador.Validate(Email) != true), "Email is invalid!");
        
    }
}