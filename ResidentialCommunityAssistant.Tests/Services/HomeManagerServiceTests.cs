namespace ResidentialCommunityAssistant.Tests.Services
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Services.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using System.Diagnostics;

    [TestFixture]
    internal class HomeManagerServiceTests
    {
        private CommunityAssistantDBContext context;
        private DbContextOptions<CommunityAssistantDBContext> dbOptions;
        private IHomeManagerService homeManagerService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CommunityAssistantDBContext>()
                .UseInMemoryDatabase("CommunityAssistantDBInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.context = new CommunityAssistantDBContext(dbOptions);

            this.homeManagerService = new HomeManagerService(context);

            var city = new City()
            {
                Id = 1,
                Name = "Пловдив",
                PostCode = "4000",
                LocalityTypeId = 1
            };

            var addressPlovdiv = new Address()
            {
                Id = 1,
                Name = "Цар Борис III-ти Обединител",
                Number = "37",
                LocationTypeId = 2,
            };
            addressPlovdiv.City = city;

            Apartament apartament = new Apartament()
            {
                Id = 1,
                Signature = "A",
                Number = 1,
                OwnerId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                AddressId = 1
            };
            Apartament apartamentWithoutOwner = new Apartament()
            {
                Id = 2,
                Signature = "A",
                Number = 2,
                AddressId = 1
            };

            ExtendedUser user = new ExtendedUser()
            {
                Id = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                FirstName = "Тодор",
                LastName = "Тодоров",
                UserName = "homeManager@mail.com",
                NormalizedUserName = "homeManager@mail.com".ToUpper(),
                Email = "homeManager@mail.com",
                NormalizedEmail = "homeManager@mail.com".ToUpper()
            };
            UserAddress userAddress = new UserAddress()
            {
                AddressId = 1,
                UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                IsUserHomeManager = true
            };

            context.Addresses.Add(addressPlovdiv);
            context.Apartaments.Add(apartament);
            context.Apartaments.Add(apartamentWithoutOwner);
            context.Users.Add(user);
            context.UsersAddresses.Add(userAddress);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }

        [Test]
        public async Task AddAddressMethod_ShouldReturnIdWhenSucceeds()
        {
            AddAddressViewModel address = new AddAddressViewModel()
            {
                CityLocalityId = 1,
                CityName = "Пловдив",
                LocationTypeId = 1,
                Name = "Хан Аспарух",
                Number = "1",
                PostCode = "4000"
            };
            int actual = await this.homeManagerService.AddAddressAsync(address);
            int expected = 2;

            Assert.AreEqual(expected, actual);

        }
        [Test]
        public async Task AddAddressMethod_ShouldReturnZeroWhenAddressExist()
        {
            AddAddressViewModel address = new AddAddressViewModel()
            {
                CityLocalityId = 1,
                CityName = "Пловдив",
                LocationTypeId = 1,
                Name = "Цар Борис III-ти Обединител",
                Number = "37",
                PostCode = "4000"
            };
            int idOfNewAddress = await this.homeManagerService.AddAddressAsync(address);

            int actual = 0;

            Assert.AreEqual(idOfNewAddress, actual);

        }

        [Test]
        public async Task AddAddressMethod_ShouldInceaseLengthOfTable()
        {
            AddAddressViewModel address = new AddAddressViewModel()
            {
                CityLocalityId = 1,
                CityName = "Пловдив",
                LocationTypeId = 1,
                Name = "Хан Аспарух",
                Number = "1",
                PostCode = "4000"
            };

            await this.homeManagerService.AddAddressAsync(address);

            int totalTableCount = this.context.Addresses.Count();

            int actual = 2;

            Assert.AreEqual(totalTableCount, actual);
        }

        [Test]
        public async Task AddApartamentByApiMethod_ShouldReturnIdWhenSucceeds()
        {
            AddAddressViewModel address = new AddAddressViewModel()
            {
                CityLocalityId = 1,
                CityName = "Пловдив",
                LocationTypeId = 1,
                Name = "Хан Аспарух",
                Number = "1",
                PostCode = "4000"
            };
            int idOfNewAddress = await this.homeManagerService.AddAddressAsync(address);

            int actual = 2;

            Assert.AreEqual(idOfNewAddress, actual);

        }

        [Test]
        public async Task AddApartamentByApiMethod_ShouldInceaseLengthOfTable()
        {
            AddAddressViewModel address = new AddAddressViewModel()
            {
                CityLocalityId = 1,
                CityName = "Пловдив",
                LocationTypeId = 1,
                Name = "Хан Аспарух",
                Number = "1",
                PostCode = "4000"
            };

            await this.homeManagerService.AddAddressAsync(address);

            int totalTableCount = this.context.Addresses.Count();

            int actual = 2;

            Assert.AreEqual(totalTableCount, actual);
        }

        [Test]
        public async Task AddApartamentMethod_ShouldIncreaseLengthOfTable()
        {
            AddApartamentViewModel apartament = new AddApartamentViewModel()
            {
                 AddressId = 1,
                 Number = 1,
                 Signature = "A"
            };

            await this.homeManagerService.AddApartamentAsync(apartament);

            int totalTableCount = this.context.Apartaments.Count();

            int actual = 3;

            Assert.AreEqual(totalTableCount, actual);
        }

        [Test]
        public async Task EditApartamentMethod_ShouldReturnTrueAtComparableObjects()
        {
            int idOfApartament = 1;
            int number = 11;

            AddApartamentViewModel apartament = new AddApartamentViewModel()
            {
                Id = idOfApartament,
                AddressId = 1,
                Number = 1,
                Signature = "A"
            };

            await this.homeManagerService.AddApartamentAsync(apartament);
            Apartament apartamentBeforeChanges = this.context.Apartaments.FirstOrDefault(a => a.Id == idOfApartament);

            ApartamentViewModel apartamentToEdit = new ApartamentViewModel()
            {
                AddressId = 1,
                Number = number,
                Signature = "A"
            };

            await this.homeManagerService.EditApartament(apartamentToEdit);

            Apartament apartamentAfterChanges = this.context.Apartaments.FirstOrDefault(a => a.Id == idOfApartament);
            bool areApartamentsEqual = apartamentBeforeChanges.Equals(apartamentAfterChanges);

            Assert.True(areApartamentsEqual);
        }

        [Test]
        public async Task GetAllApartamentsInSpecificAddressMethod_ShouldReturnCountOfAllApartaments()
        {
           
            AddApartamentViewModel apartament = new AddApartamentViewModel()
            {
                Id = 1,
                AddressId = 1,
                Number = 1,
                Signature = "A"
            };
            await this.homeManagerService.AddApartamentAsync(apartament);

            var listOfApartaments = await this.homeManagerService.GetAllApartamentsInSpecificAddressAsync(1);
            int actual = listOfApartaments.Count();
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetApartamentByIdMethod_ShouldReturnInstanceOfApartamentViewModel()
        {

            AddApartamentViewModel apartament = new AddApartamentViewModel()
            {
                Id = 1,
                AddressId = 1,
                Number = 1,
                Signature = "A"
            };
            await this.homeManagerService.AddApartamentAsync(apartament);

            var searchedApartament = await this.homeManagerService.GetApartamentByIdAsync(1);            

            Assert.NotNull(searchedApartament);
            Assert.AreEqual(searchedApartament.ApartamentId, apartament.Id);
        }

        [Test]
        public async Task GetApartamentByIdMethod_ShouldReturnNullWhenIdNotExist()
        {

            AddApartamentViewModel apartament = new AddApartamentViewModel()
            {
                Id = 1,
                AddressId = 1,
                Number = 1,
                Signature = "A"
            };
            await this.homeManagerService.AddApartamentAsync(apartament);

            int notExistingId = 100;

            var searchedApartament = await this.homeManagerService.GetApartamentByIdAsync(notExistingId);

            Assert.Null(searchedApartament);
        }
        [Test]
        public void RemoveUserFromApartamentMethod_ShouldReturnNullToUserPropertyWhenIsRemoved()
        {
            int apartamentId = 1;           

            this.homeManagerService.RemoveUserFromApartament(apartamentId);

            Apartament apartament = this.context.Apartaments.FirstOrDefault(a => a.Id == apartamentId);

            Assert.Null(apartament.OwnerId);
        }

        [Test]
        public async Task GetHomeManagerIdMethod_ReturnIdOfUserWithHomeManagerRole()
        {
            int apartamentId = 1;

            string actual = await this.homeManagerService.GetHomeManagerIdAsync(apartamentId);

            string expected = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetHomeManagerIdMethod_ReturnEmptyStringWhenInputIsIncorect()
        {
            int apartamentId = 34;

            string actual = await this.homeManagerService.GetHomeManagerIdAsync(apartamentId);

            string expected = "";

            Assert.That(actual, Is.EqualTo(expected));
        }
       
    }
}
