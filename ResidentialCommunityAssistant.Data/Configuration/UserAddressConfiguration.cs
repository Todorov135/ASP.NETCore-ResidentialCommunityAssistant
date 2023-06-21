namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;

    internal class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasData(
                new UserAddress()
                {
                    AddressId = 2,
                    UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61"
                },
                new UserAddress()
                {
                    AddressId = 2,
                    UserId = "579b52e0-38e4-4f41-a30f-31e72767c536"
                },
                new UserAddress()
                {
                    AddressId = 2,
                    UserId = "88d33982-06d8-43f0-b809-7d6ed7f3ab23"
                });
        }
    }
}
