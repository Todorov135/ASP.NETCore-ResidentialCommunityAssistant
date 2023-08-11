namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;
    using System;

    public class ApartamentConfiguration : IEntityTypeConfiguration<Apartament>
    {
        public void Configure(EntityTypeBuilder<Apartament> builder)
        {
            var apartaments = ApartamentSeed();

            builder.HasData(apartaments);
        }

        private IEnumerable<Apartament> ApartamentSeed()
        {
            var apartaments = new List<Apartament>()
            {
                new Apartament()
                {
                    Id= 1,
                    Signature = "A",
                    Number = 1,
                    OwnerId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                    AddressId = 2
                },
                new Apartament()
                {
                    Id= 2,
                    Signature = "A",
                    Number = 2,
                    OwnerId = "579b52e0-38e4-4f41-a30f-31e72767c536",
                    AddressId = 2
                },
                new Apartament()
                {
                    Id= 3,
                    Signature = "A",
                    Number = 3,
                    OwnerId = "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                    AddressId = 2
                },

            };

            return apartaments;
        }
    }
}
