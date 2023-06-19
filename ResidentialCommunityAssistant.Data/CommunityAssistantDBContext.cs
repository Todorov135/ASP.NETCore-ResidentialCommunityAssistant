namespace ResidentialCommunityAssistant.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data.Configuration;
    using ResidentialCommunityAssistant.Data.Models;

    public class CommunityAssistantDBContext : IdentityDbContext
    {
        public CommunityAssistantDBContext(DbContextOptions<CommunityAssistantDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HomeownersAddresses>()
                   .HasKey(ha => new { ha.HomeownerId, ha.AddressId });

            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}