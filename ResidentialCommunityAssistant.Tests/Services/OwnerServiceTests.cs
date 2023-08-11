namespace ResidentialCommunityAssistant.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using ResidentialCommunityAssistant.Services.Services.Owner;

    [TestFixture]
    internal class OwnerServiceTests
    {
        private CommunityAssistantDBContext context;
        private DbContextOptions<CommunityAssistantDBContext> dbOptions;
        private IOwnerService ownerService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<CommunityAssistantDBContext>()
                .UseInMemoryDatabase("CommunityAssistantDBInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CommunityAssistantDBContext(dbOptions);

            ownerService = new OwnerService(context);

            City city = new City()
            {
                Id = 1,
                Name = "Пловдив",
                PostCode = "4000",
                LocalityTypeId = 1
            };
            LocalityType cityLocality = new LocalityType()
            {
                Id = 1,
                Name = "гр."
            };
            LocalityType villаgeLocality = new LocalityType()
            {
                Id = 2,
                Name = "с."
            };
            LocationType strLocation = new LocationType()
            {
                Id = 1,
                Name = "ул."
            };
            LocationType avenueLocation = new LocationType()
            {
                Id = 2,
                Name = "бул."
            };
            Address addressPlovdiv = new Address()
            {
                Id = 1,
                Name = "Цар Борис III-ти Обединител",
                Number = "37",
                LocationTypeId = 2,
                CityId = 1
            };
            Apartament apartament = new Apartament()
            {
                Id = 1,
                Signature = "A",
                Number = 1,
                OwnerId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                AddressId = 1
            };
            CommunityTopic topic = new CommunityTopic()
            {
                Id = 1,
                Title = "Озеленяване на градинка",
                Description = "Закупуване, засаждане и подръжка на тревни чимове за двора пред сградата.",
                CreatedOn = Convert.ToDateTime("21/06/2023 03:05:15 PM"),
                CreatorId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
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
            UserAddress ua = new UserAddress()
            {
                AddressId = 1,
                UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61"
            };
            
            context.Cities.Add(city);
            context.LocalityTypes.Add(cityLocality);
            context.LocalityTypes.Add(villаgeLocality);
            context.LocationTypes.Add(strLocation);
            context.LocationTypes.Add(avenueLocation);
            context.Addresses.Add(addressPlovdiv);
            context.Apartaments.Add(apartament);
            context.CommunityTopics.Add(topic);
            context.Users.Add(user);
            context.UsersAddresses.Add(ua);

            context.SaveChanges();

        }
        [Test]
        public async Task GetAllLocalityTypesMethod_ReturnCountOfLocalities()
        {
            var localities = await this.ownerService.GetAllLocalityTypesAsync();
            int actual = localities.Count();

            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllLocationTypesMethod_ReturnCountOfLocations()
        {
            var locations = await this.ownerService.GetAllLocationTypesAsync();
            int actual = locations.Count();

            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllTopicsForAddressMethod_ReturnCountOfAddedTopics()
        {
            int addressId = 1;
            var currentTopics = await this.ownerService.GetAllTopicsForAddressAsync(addressId);
            int actual = currentTopics.Count();

            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetOwnedAddressesMethod_ReturnCountOfOwnedAddresses()
        {
            string userId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";
            var ownedAddresses = await this.ownerService.GetOwnedAddressesAsync(userId);
            int actual = ownedAddresses.Count();

            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllApartamentsMethod_ReturnCountOfApartaments()
        {
            int addressId = 1;
            var apartaments = await this.ownerService.GetAllApartamentsAsync(addressId);

            int actual = apartaments.Count();
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task AddCommunityTopicAsyncMethod_IncreaseNumberOfTopics()
        {
            AddCommunityTopicViewModel newTopic = new AddCommunityTopicViewModel()
            {
                AddressId = 1,
                CreatorId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                Description = "Лорем ипсум лорем ипсум",
                Title = "Лорем ипсум"
            };

            await this.ownerService.AddCommunityTopicAsync(newTopic);

            int actual = context.CommunityTopics.Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetCommunityTopicMethod_ReturnInstanceOfTypeCommunityTopicViewModel()
        {
            int topicId = 1;

            var topic = await this.ownerService.GetCommunityTopicAsync(topicId);            

            Assert.NotNull(topic);
        }
    }
}
