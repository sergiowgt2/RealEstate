using Xunit;
using RealEstate.Domain.Entities.Base;
using System;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Tests.Unit
{
    public class BaseEntityTests
    {
        [Fact]
        public void CreatedBy_MustNotBeEmpty()
        {
            // Arrange
            var entity = new BaseEntity
            {
                CreatedAt = DateTime.Now,
                CreatedBy = ""
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Created By cannot be empty", exception.Message);
            
        }
        
        [Fact]
        public void UpdatedBy_MustBeNotEmpty_IfUpdatedAt_IsNotNull()
        {
            // Arrange
            var entity = new BaseEntity
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = DateTime.Now,
                UpdatedBy = null
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Updated By cannot be empty", exception.Message);
        }

        [Fact]
        public void UpdatedAt_MustBeNotNull_IfUpdatedBy_IsNotNull()
        {
            // Arrange
            var entity = new BaseEntity
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "ALGO",
                UpdatedAt = null,
                UpdatedBy = "ALGO"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Updated At cannot be empty", exception.Message);
        }
    }
}