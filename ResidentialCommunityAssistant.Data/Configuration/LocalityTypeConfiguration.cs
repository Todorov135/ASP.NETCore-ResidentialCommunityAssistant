namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;

    public class LocalityTypeConfiguration : IEntityTypeConfiguration<LocalityType>
    {
        public void Configure(EntityTypeBuilder<LocalityType> builder)
        {
            builder.HasData(
                new LocalityType()
                {
                    Id = 1,
                    Name = "гр."
                },
                new LocalityType()
                {
                    Id = 2,
                    Name = "с."
                });
        }
    }
}
