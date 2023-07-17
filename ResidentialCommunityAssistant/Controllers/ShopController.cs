namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Extensions;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;
    using ResidentialCommunityAssistant.Services.Models.Shop.ExtendedUser;

    public class ShopController : BaseController
    {
        private readonly IShopService shopService;
        public ShopController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var allProducts = await this.shopService.GetAllProductsAsync();

            return View(allProducts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCard(int id)
        {
            var userId = this.User.Id();

            if (id == 0 || userId == null)
            {
                return RedirectToAction(nameof(AllProducts));
            }

            await shopService.AddProductToShoppingCard(id, userId);           

            return RedirectToAction(nameof(AllProducts));
        }
        [HttpPost]
        public async Task<IActionResult> IncreasingTheNumberToBePurchased(int id)
        {
            var userId = this.User.Id();

            if (id == 0 || userId == null)
            {
                return RedirectToAction(nameof(AllProducts));
            }

            await shopService.AddProductToShoppingCard(id, userId);

            return RedirectToAction(nameof(ShoppingCard));
        }

        [HttpPost]
        public IActionResult DecreasingTheNumberToBePurchased(int id)
        {
            var userId = this.User.Id();

            if (id == 0 || userId == null)
            {
                return RedirectToAction(nameof(AllProducts));
            }

            shopService.RemoveProductToShoppingCard(id, userId);

            return RedirectToAction(nameof(ShoppingCard));
        }

        public async Task<IActionResult> ShoppingCard()
        {
            string userId = this.User.Id();
            var shoppingCard = await this.shopService.GetAllProductsInShoppingCardAsync(userId);

            return View(shoppingCard);
        }

        public async Task<IActionResult> OrderProducts()
        {
            string userId = this.User.Id();

            int currentOrderId = await this.shopService.ApprovedOrder(userId);
            var orderNum = new OrderNumberViewModel(currentOrderId);

            return View(orderNum);
        }

        [HttpGet]
        public async Task<IActionResult> ShopHistory()
        {
            string userId = this.User.Id();
            var orders = await this.shopService.GetAllOrdersByUserIdAsync(userId);

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ShopHistoryDetails(int id)
        {
            if (id == 0)
            {
                return RedirectToAction(nameof(ShopHistory));
            }

            var details = await this.shopService.GetShopHistoryDetails(id);

            return View(details);
        }
    }
}
