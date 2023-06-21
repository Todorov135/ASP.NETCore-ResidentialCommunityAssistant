namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Home;
    using ResidentialCommunityAssistant.Services.Models.Home;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Owner");
            }

            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ChekForExistingAddress(string cityName, string addressName, string number)
        {
            var addressModel = this.homeService.GetAddressAsync(cityName, addressName, number);

            if (addressModel.Result != null)
            {
                return RedirectToAction(nameof(Index), "Owner");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}