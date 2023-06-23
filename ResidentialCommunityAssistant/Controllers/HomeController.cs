namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Home;
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
                return RedirectToAction("ChooseAddress", "Owner");
            }

            return View();
        }
        
        

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddressSearch()
        {            
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddressSearch(string cityName, string addressName, string number)
        {
            var addressModel = await this.homeService.GetAddressAsync(cityName, addressName, number);
            
            if (addressModel != null)
            {
                return RedirectToAction("AddressDetails", "Home", new {addressId = addressModel.Id});
            }
            else
            {
                return View("NotFoundAddress");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AddressDetails(int addressId)
        {
            var addressModel = await this.homeService.GetAddressByIdAsync(addressId);

            return View(addressModel);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}