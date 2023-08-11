namespace ResidentialCommunityAssistant.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;
    using ResidentialCommunityAssistant.Services.Models.Shop.ShopManager;
    using ResidentialCommunityAssistant.Services.Services.Shop;

    [TestFixture]
    internal class ShopServiceTests
    {
        private CommunityAssistantDBContext context;
        private DbContextOptions<CommunityAssistantDBContext> dbOptions;
        private IShopService shopService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<CommunityAssistantDBContext>()
                .UseInMemoryDatabase("CommunityAssistantDBInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CommunityAssistantDBContext(dbOptions);

            this.shopService = new ShopService(context);

            Product pirateFlag = new Product()
            {
                Id = 1,
                Name = "Пиратско знаме",
                Description = "Ако използвате uTorrent, това е знамето за Вас.",
                ImgURL = "https://shop.flagfactory.bg/image/cache/catalog/products/flags/pirates/pirates_mockups/pirate2_mockup-600x360.png",
                Price = 10.00M,
                Quantity = 100
            };
            Product sayanFlag = new Product()
            {
                Id = 2,
                Name = "Саянско знаме",
                Description = "Желаете да завоювате чужди светове?!? Искате жителите да треперя при Вашето присъствие?!? Станете саян!",
                ImgURL = "https://external-preview.redd.it/xLN_fXFlM6wM84w_VGkRJut0LqNDug4gs-c66_5zZ9o.jpg?auto=webp&s=3dbf10a8efddb301911796c52fadba948206fdbf",
                Price = 100.00M,
                Quantity = 100
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
            Order order = new Order()
            {
                Id = 1,
                CreatedOn = DateTime.Now,
                User = user                
            };
            OrderProduct orderedProduct = new OrderProduct()
            {
                Order = order,
                Product = pirateFlag,
                Quantity = 1
            };

            context.Products.Add(pirateFlag);
            context.Products.Add(sayanFlag);
            context.Users.Add(user);
            context.Orders.Add(order);
            context.OrdersProducts.Add(orderedProduct);

            context.SaveChanges();
        }

        [Test]
        public async Task AddProductToShoppingCardMethod_IncreaseNumberOfCollection()
        {
            int productId = 1;
            string userId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";
            await shopService.AddProductToShoppingCard(productId, userId);

            int actual = this.context.OrdersCaches.Count();
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task ApprovedOrderMethod_ReturnIntegerAsOrderNumber()
        {
            int productId = 1;
            string userId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";
            await shopService.AddProductToShoppingCard(productId, userId);

            int actual = await shopService.ApprovedOrder(userId); //OrderNumber
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllOrdersByUserIdMethod_ReturnCountOfAllOrders()
        {
            int productId = 1;
            string userId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";
            await shopService.AddProductToShoppingCard(productId, userId);
            await shopService.ApprovedOrder(userId);
            var orders = await this.shopService.GetAllOrdersByUserIdAsync(userId);
            int actual = orders.Count();

            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllProductsMethod_ReturnCountOfAllProducts()
        {           
            var products = await this.shopService.GetAllProductsAsync();
            int actual = products.Count();

            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllProductsInShoppingCardMethod_ReturnCountOfAllProductsAddedInShoppingCard()
        {
            int productId = 1;
            string userId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";
            await shopService.AddProductToShoppingCard(productId, userId);

            var products = await this.shopService.GetAllProductsInShoppingCardAsync(userId);
            int actual = products.Count();

            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetShopHistoryDetailsMethod_ReturnInstanceOfOrderHistoryViewModel()
        {
            int orderId = 1;
            var orderHistoryDetail = await this.shopService.GetShopHistoryDetails(orderId);

            Assert.NotNull(orderHistoryDetail);
        }
        [Test]
        public async Task RemoveProductToShoppingCardMethod_DecreaseNumberOfCollection()
        {
            int productId = 1;
            string userId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61";
            await shopService.AddProductToShoppingCard(productId, userId);
            shopService.RemoveProductToShoppingCard(productId, userId);
            int actual = this.context.OrdersCaches.Count();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllProductsForShopManagerMethod_ReturnCountOfAllProductsVisibleForShopManager()
        {
            var products = await this.shopService.GetAllProductsForShopManagerAsync();
            int actual = products.Count();

            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetProductToEditMethod_ReturnInstanceOfExistingProduct()
        {
            int productId = 1;
            var product = await this.shopService.GetProductToEditAsync(productId);
           
            Assert.NotNull(product);
        }

        [Test]
        public async Task AddQuantityToProductMethod_ShouldIncreaseQuantityOfProduct()
        {
            int quantityToAdd = 1;
            EditProductViewModel? productToEdit = this.context.Products
                                                             .Where(p => p.Id == 1)
                                                             .Select(ep => new EditProductViewModel()
                                                             {
                                                                 Description = ep.Description,
                                                                 Id = ep.Id,
                                                                 ImgURL = ep.ImgURL,
                                                                 Name = ep.Name,
                                                                 Price = ep.Price,
                                                                 Quantity = ep.Quantity
                                                             }).FirstOrDefault();


            AddQuantityProductViewModel product = new AddQuantityProductViewModel()
            {
                QuantityToAdd = quantityToAdd,
                CurrentProduct = productToEdit
            };

            await shopService.AddQuantityToProductAsync(product);
            int actual = this.context.Products.Where(p => p.Id == 1).Select(q => q.Quantity).FirstOrDefault();
            int expected = 101;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task AddProductMethod_IncreaseNumberOfCollectionOfProducts()
        {
            EditProductViewModel product = new EditProductViewModel()
            {
                Name = "NewProduct",
                Description = "NewlyNewProduct",
                Price = 100,
                ImgURL = "SomeURL",
                Quantity = 1
            };

            await this.shopService.AddProductAsync(product);
            int actual = this.context.Products.Count();
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

    }
}
