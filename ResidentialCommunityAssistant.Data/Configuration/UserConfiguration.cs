namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;

    internal class UserConfiguration : IEntityTypeConfiguration<ExtendedUser>
    {
        public void Configure(EntityTypeBuilder<ExtendedUser> builder)
        {
            var users = UserSeeder();

            builder.HasData(users);
        }

        private IEnumerable<ExtendedUser> UserSeeder()
        {
            var users = new List<ExtendedUser>();

            PasswordHasher<ExtendedUser> hasher = new PasswordHasher<ExtendedUser>();

            ExtendedUser homeManager = new ExtendedUser()
            {
                Id = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                FirstName = "Тодор",
                LastName = "Тодоров",
                UserName = "homeManager@mail.com",
                NormalizedUserName = "homeManager@mail.com".ToUpper(),
                Email = "homeManager@mail.com",
                NormalizedEmail = "homeManager@mail.com".ToUpper()                
            };
            homeManager.PasswordHash = hasher.HashPassword(homeManager, "homemanager");
            users.Add(homeManager);

            ExtendedUser firstOwner = new ExtendedUser()
            {
                Id = "579b52e0-38e4-4f41-a30f-31e72767c536",
                FirstName = "Иван",
                LastName = "Иванов",
                UserName = "firstOwner@mail.com",
                NormalizedUserName = "firstOwner@mail.com".ToUpper(),
                Email = "firstOwner@mail.com",
                NormalizedEmail = "firstOwner@mail.com".ToUpper()
            };
            firstOwner.PasswordHash = hasher.HashPassword(firstOwner, "firstOwner");
            users.Add(firstOwner);

            ExtendedUser secondOwner = new ExtendedUser()
            {
                Id = "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                FirstName = "Петър",
                LastName = "Петров",
                UserName = "secondOwner@mail.com",
                NormalizedUserName = "secondOwner@mail.com".ToUpper(),
                Email = "secondOwner@mail.com",
                NormalizedEmail = "secondOwner@mail.com".ToUpper()
            };
            secondOwner.PasswordHash = hasher.HashPassword(secondOwner, "secondOwner");
            users.Add(secondOwner);

            return users;
        }
    }

    
}
