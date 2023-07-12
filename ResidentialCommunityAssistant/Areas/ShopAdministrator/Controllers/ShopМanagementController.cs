namespace ResidentialCommunityAssistant.Areas.ShopAdministrator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "StoreManager")]
    [Area("ShopAdministrator")]
    public class ShopМanagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
