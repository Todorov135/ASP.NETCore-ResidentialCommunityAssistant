namespace ResidentialCommunityAssistant.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Home;
    using ResidentialCommunityAssistant.Services.Models.Home;
    using ResidentialCommunityAssistant.Services.Services.Home;

    [TestFixture]
    internal class HomeServiceTests
    {
        private CommunityAssistantDBContext context;
        private DbContextOptions<CommunityAssistantDBContext> dbOptions;
        private IHomeService homeService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<CommunityAssistantDBContext>()
                .UseInMemoryDatabase("CommunityAssistantDBInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CommunityAssistantDBContext(dbOptions);

            homeService = new HomeService(context);

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

            context.Addresses.Add(addressPlovdiv);
            context.SaveChanges();

        }

        [Test]
        public async Task AddressExistInDatabase_ReturnInstance()
        {
            string cityName = "Пловдив";
            string addressName = "Цар Борис III-ти Обединител";
            string number = "37";

            var existingAddress = await homeService.GetAddressAsync(cityName, addressName, number);

            Assert.NotNull(existingAddress);
        }


        [Test]
        public async Task AddressNotExistInDatabase_ReturnNull()
        {
            string cityName = "София";
            string addressName = "Цар Борис III-ти Обединител";
            string number = "37";

            var existingAddress = await homeService.GetAddressAsync(cityName, addressName, number);

            Assert.Null(existingAddress);
        }

        [Test]
        public async Task GetAddressByIdMethod_ReturnsInstance()
        {
            int addressId = 1;

            var existingAddress = await homeService.GetAddressByIdAsync(addressId);

            Assert.NotNull(existingAddress);
        }

        [Test]
        public async Task GetAddressByIdMethod_ShouldReturnNullIfNotFound()
        {
            int addressId = 4;

            var existingAddress = await homeService.GetAddressByIdAsync(addressId);

            Assert.Null(existingAddress);
        }

    }
}
