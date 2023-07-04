namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;
    using System;

    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var addresses = AddressSeed();

            builder.HasData(addresses);
        }

        private IEnumerable<Address> AddressSeed()
        {
            var addresses = new List<Address>();

            var addressPlovdiv = new Address()
            {
                Id = 1,
                Name = "Цар Борис III-ти Обединител",
                Number = "37",
                LocationTypeId = 2,
                CityId = 1                
            };
            addresses.Add(addressPlovdiv);

            var addressSofia = new Address()
            {
                Id = 2,
                Name = "Александър Малинов",
                Number = "78",
                LocationTypeId = 2,
                CityId = 2
            };
            addresses.Add(addressSofia);

            return addresses;
        }
    }
}
