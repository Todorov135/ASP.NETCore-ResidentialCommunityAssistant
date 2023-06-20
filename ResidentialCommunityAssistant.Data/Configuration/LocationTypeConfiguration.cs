namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;

    internal class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder)
        {
            builder.HasData( 
                new LocationType()
                {
                    Id = 1,
                    Name = "ул."
                },
                new LocationType()
                {
                    Id = 2,
                    Name = "бул."
                });
        }
    }
}
