namespace ResidentialCommunityAssistant.Areas.ShopAdministrator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;
    using ResidentialCommunityAssistant.Services.Models.Shop.ShopManager;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;

    [Authorize(Roles = "StoreManager")]
    [Area("ShopAdministrator")]
    public class ShopМanagementController : Controller
    {
        private readonly IShopService shopService;

        public ShopМanagementController(IShopService shopService)
        {
            this.shopService = shopService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var products = await this.shopService.GetAllProductsForShopManagerAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await this.shopService.GetProductToEditAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await this.shopService.EditProductAsync(product);

            return RedirectToAction(nameof(AllProducts));
        }

        [HttpGet]
        public async Task<IActionResult> AddProductQuantity(int id)
        {
            var product = new AddQuantityProductViewModel();
            product.CurrentProduct = await this.shopService.GetProductToEditAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductQuantity(AddQuantityProductViewModel product, int productId)
        {
            var newProduct = new AddQuantityProductViewModel()
            {
                CurrentProduct = await this.shopService.GetProductToEditAsync(productId),
                QuantityToAdd = product.QuantityToAdd
            };

            if (newProduct.QuantityToAdd <= 0 
                || newProduct.QuantityToAdd > 5000
                || newProduct.CurrentProduct == null)
            {
                return View(newProduct);
            }

            await this.shopService.AddQuantityToProductAsync(newProduct);

            return RedirectToAction(nameof(AllProducts));
        }

        [HttpGet]
        public IActionResult AddProduct() 
        {
            var product = new EditProductViewModel();

            return View(product);
        }

        public async Task<IActionResult> AddPRoduct(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await this.shopService.AddProductAsync(product);

            return RedirectToAction(nameof(AllProducts));
        }
    }
}
