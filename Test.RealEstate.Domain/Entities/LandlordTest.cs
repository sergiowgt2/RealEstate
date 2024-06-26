﻿using Xunit;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;

namespace Test.RealEstate.Domain.Entities
{
    public class LandlordTest
    {
        [Fact]
        public void CpfCnpj_MustNotBeEmpty()
        {
            var landlord = new Landlord
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = ""
            };
            var exception = Assert.Throws<DomainException>(() => landlord.Validate());
            Assert.Equal("CPF/CNPJ cannot be empty!", exception.Message);
        }

        [Fact]
        public void CpfCnpj_MustNotBeInvalid()
        {
            var landlord = new Landlord
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "11"
            };
            var exception = Assert.Throws<DomainException>(() => landlord.Validate());
            Assert.Equal("CPF/CNPJ is invalid!", exception.Message);
        }

        [Fact]
        public void CellPhone_MustNotBeInvalid()
        {
            var landlord = new Landlord
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "12345678910",
                CellPhone = "11"
            };
            var exception = Assert.Throws<DomainException>(() => landlord.Validate());
            Assert.Equal("Cellphone is invalid!", exception.Message);
        }
        
        [Fact]
        public void Email_MustNotBeInvalid()
        {
            var landlord = new Landlord
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
            var exception = Assert.Throws<DomainException>(() => landlord.Validate());
            Assert.Equal("Email is invalid!", exception.Message);
        }
        
        [Fact]
        public void Lanlord_tests_ok()
        {
            var landlord = new Landlord
            {
                Name = "Pedro",
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                CnpjCpf = "12345678910",
                CellPhone = "21989593059",
                Email = "test@gmail.com"
            };
            landlord.Validate();
            Assert.True(true);
        }

    }
}