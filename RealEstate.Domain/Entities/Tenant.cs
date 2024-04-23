using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Entities.Base;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Validators;

namespace RealEstate.Domain.Entities;

public class Tenant : NamedBaseEntity
{
    [MaxLength(14)]
    public string CnpjCpf { get; set; }
    [MaxLength(14)]
    public string CellPhone { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    
    public ICollection<LeaseContract> LeaseContracts { get; set; }

    public override void Validate()
    {
        DomainException.When(String.IsNullOrWhiteSpace(CnpjCpf), "CPF/CNPJ must not be empty!");
        DomainException.When(String.IsNullOrWhiteSpace(CellPhone), "Cellphone must not be empty!");
        DomainException.When(String.IsNullOrWhiteSpace(Email), "Email must not be empty!");
        DomainException.When(CpfCnpjValidador.Validate(CnpjCpf) == false, "CPF/CNPJ is invalid!");
        DomainException.When(CellphoneValidator.Validate(CellPhone) == false, "Cellphone is invalid!");
        DomainException.When(EmailValidador.Validate(Email) == false, "Email is invalid!");
    }
}