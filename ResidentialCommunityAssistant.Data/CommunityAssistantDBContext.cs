﻿namespace ResidentialCommunityAssistant.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data.Configuration;
    using ResidentialCommunityAssistant.Data.Models;

    public class CommunityAssistantDBContext : IdentityDbContext<ExtendedUser>
    {
        public CommunityAssistantDBContext(DbContextOptions<CommunityAssistantDBContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Apartament> Apartaments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CommunityTopic> CommunityTopics { get; set; }       
        public DbSet<HomeManagerApproval> HomeManagersApprovals { get; set; }
        public DbSet<LocalityType> LocalityTypes { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserAddress> UsersAddresses { get; set; }
        public DbSet<Order> UsersProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAddress>()
                   .HasKey(ha => new { ha.UserId, ha.AddressId });
            
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new ApartamentConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CommunityTopicConfiguration());
            builder.ApplyConfiguration(new LocalityTypeConfiguration());
            builder.ApplyConfiguration(new LocationTypeConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new RoleUserConfiguration());
            builder.ApplyConfiguration(new UserAddressConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());           

            base.OnModelCreating(builder);
        }
    }
}