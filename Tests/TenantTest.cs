using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Tests.Unit
{
    public class TenantTest
    {
        [Fact]
        public void CpfCnpj_MustNotBeEmpty()
        {
            var tenant = new Tenant
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "",
                CellPhone = "21989593059",
                Email = "test@gmail.com"
            };
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("CPF/CNPJ must not be empty!", exception.Message);
        }
        
        [Fact]
        public void Phone_MustNotBeEmpty()
        {
            var tenant = new Tenant
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "12345678910",
                CellPhone = "",
                Email = "test@gmail.com"
            };
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Cellphone must not be empty!", exception.Message);
        }
        
        [Fact]
        public void Email_MustNotBeEmpty()
        {
            var tenant = new Tenant
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "12345678910",
                CellPhone = "21989593059",
                Email = ""
            };
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Email must not be empty!", exception.Message);
        }
        
        [Fact]
        public void CpfCnpj_MustBeValid()
        {
            var tenant = new Tenant
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "11",
                CellPhone = "21989593059",
                Email = "test@gmail.com"
            };
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("CPF/CNPJ is invalid!", exception.Message);
        }
        
        [Fact]
        public void Email_MustHaveValidFormat()
        {
            var tenant = new Tenant
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "12345678910",
                CellPhone = "21989593059",
                Email = "t.com"
            };
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Email is invalid!", exception.Message);
        }
        
        [Fact]
        public void Phone_MustHaveValidFormat()
        {
            var tenant = new Tenant
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "12345678910",
                CellPhone = "21982937469593059",
                Email = "test@gmail.com"
            };
            var exception = Assert.Throws<DomainException>(() => tenant.Validate());
            Assert.Equal("Cellphone is invalid!", exception.Message);
        }
    
    } 
}

