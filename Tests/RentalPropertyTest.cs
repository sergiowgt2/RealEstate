using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;

namespace RealEstate.Tests.Unit
{

    public class RentalPropertyTest
    {
        private RentalProperty CreateRentalProperty(string nickname = "", string address = "")
        {
            return new RentalProperty()
            {
                
                CreatedAt = DateTime.Now,
                CreatedBy = "Pedro",
                UpdatedAt = null,
                UpdatedBy = null,

                NickName = nickname,
                Address = address,

            };
        }

        [Fact]
        public void NickName_MustNotBeEmpty()
        {
            var rentalProperty = CreateRentalProperty();
            var exception = Assert.Throws<DomainException>(() => rentalProperty.Validate());
            Assert.Equal("NickName must not be empty!", exception.Message);
        }

        [Fact]
        public void Address_MustNotBeEmpty()
        {
            var rentalProperty = CreateRentalProperty(nickname: "ordep");
            var exception = Assert.Throws<DomainException>(() => rentalProperty.Validate());
            Assert.Equal("Address must not be empty!", exception.Message);
        }

        [Fact]
        public void RentalProperty_Tests_Ok()
        {
            var rentalProperty = CreateRentalProperty(nickname: "Ordep", address: "Miami");
            rentalProperty.Validate();
            Assert.True(true);
        }
    }
}