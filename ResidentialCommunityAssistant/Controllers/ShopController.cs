namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Extensions;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;

    public class ShopController : Controller
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

           

            return RedirectToAction(nameof(AllProducts));
        }
    }
}
