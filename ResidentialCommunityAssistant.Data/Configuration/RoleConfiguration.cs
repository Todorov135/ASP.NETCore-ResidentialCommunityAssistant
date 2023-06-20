namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole()
            {
                Id = "492c2f53-e30a-4da9-b639-e599ef6d7794",
                Name = "HomeManager",
                NormalizedName = "HomeManager".ToUpper()
            },
            new IdentityRole()
            {
                Id = "df52a94f-e70f-4872-a5a8-48631411afdb",
                Name = "StoreManager",
                NormalizedName = "StoreManager".ToUpper()
            });
        }
    }
}
