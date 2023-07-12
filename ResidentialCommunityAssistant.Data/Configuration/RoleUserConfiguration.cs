namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class RoleUserConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>()
            {
                RoleId = "492c2f53-e30a-4da9-b639-e599ef6d7794",
                UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61"
            },
            new IdentityUserRole<string>()
            {
                RoleId = "df52a94f-e70f-4872-a5a8-48631411afdb",
                UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61"
            });
        }
    }


}
