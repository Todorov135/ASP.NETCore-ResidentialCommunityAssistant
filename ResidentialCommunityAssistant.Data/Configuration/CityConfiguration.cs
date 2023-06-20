namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;

    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City()
                {
                    Id = 1,
                    Name = "Пловдив",
                    PostCode = "4000",
                    LocalityTypeId = 1
                },
                new City()
                {
                    Id = 2,
                    Name = "София",
                    PostCode = "1000",
                    LocalityTypeId = 1
                });
        }
    }
}
