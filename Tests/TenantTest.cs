using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Tests.Unit
{
    public class TenantTest
    {
        private Tenant CreateTenant(string cnpjCpf = "", string cellPhone = "", string email = "")
        {
            return new Tenant()
            {
                /* Já foram testados pela herança */
                UpdatedAt = null,
                UpdatedBy = null,
                CreatedBy = "Ja foi testado",
                CreatedAt = DateTime.Now,
                Name = "Já foi testado",
                /* fim => Já foram testados pela herança */
                
                CnpjCpf = cnpjCpf,
                CellPhone = cellPhone,
                Email = email,
                
            };
        }
        
        
        [Fact]
        public void CpfCnpj_MustNotBeEmpty()
        {
            var tenant = CreateTenant();
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("CPF/CNPJ must not be empty!", exception.Message);
        }
        
        [Fact]
        public void CpfCnpj_MustBeValid()
        {
            var tenant = CreateTenant(cnpjCpf:"Algo");
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("CPF/CNPJ is invalid!", exception.Message);
        }
        
        [Fact]
        public void Phone_MustNotBeEmpty()
        {
            var tenant = CreateTenant(cnpjCpf:"01834522757");
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Cellphone must not be empty!", exception.Message);
        }
        
        [Fact]
        public void Phone_MustHaveValidFormat()
        {
            var tenant = CreateTenant(cnpjCpf:"01834522757", cellPhone:"xxxx");
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Cellphone is invalid!", exception.Message);
        }
        [Fact]
        public void Email_MustNotBeEmpty()
        {
            var tenant = CreateTenant(cnpjCpf:"01834522757", cellPhone:"21964049300");
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Email must not be empty!", exception.Message);
        }
        
        [Fact]
        public void Email_MustHaveValidFormat()
        {
            
            var tenant = CreateTenant(cnpjCpf:"01834522757", cellPhone:"21964049300", email:"xxxx");
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Email is invalid!", exception.Message);
        }
    } 
}

