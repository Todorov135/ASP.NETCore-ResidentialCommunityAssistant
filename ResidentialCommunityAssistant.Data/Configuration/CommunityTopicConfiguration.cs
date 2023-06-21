namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;

    internal class CommunityTopicConfiguration : IEntityTypeConfiguration<CommunityTopic>
    {
        public void Configure(EntityTypeBuilder<CommunityTopic> builder)
        {
            builder.HasData(
                new CommunityTopic()
                {
                    Id = 1,
                    Title = "Озеленяване на градинка",
                    Description = "Закупуване, засаждане и подръжка на тревни чимове за двора пред сградата.",
                    CreatedOn = Convert.ToDateTime("21/06/2023 03:05:15 PM"),
                    CreatorId = "579b52e0-38e4-4f41-a30f-31e72767c536",
                    AddressId = 2
                });
        }
    }
}
