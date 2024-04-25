using Xunit;
using RealEstate.Domain.Entities.Base;
using System;
using RealEstate.Domain.Exceptions;

namespace Test.RealEstate.Domain.Entities.Base
{
    public class NamedBaseEntityTest
    {
        [Fact]
        public void Name_MustNotBeEmpty()
        {
            var namedEntity = new NamedBaseEntity
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "ALGO",
                Name = ""
            };

            var exception = Assert.Throws<DomainException>(() => namedEntity.Validate());
            Assert.Equal("Name cannot be empty!", exception.Message);
        }
    }
}