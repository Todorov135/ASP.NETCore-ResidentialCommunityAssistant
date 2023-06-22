namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Extensions;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.Owner;

    public class OwnerController : BaseController
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public IActionResult Index()
        {
            return View();
        }
           

        [HttpGet]
        public async Task<IActionResult> ChooseAddress()
        {
            var userId = this.User.Id();
            var allOwnedAddresses = new SelectedOwnedAddressViewModel();
            allOwnedAddresses.OwnedAddresses = await this.ownerService.GetOwnedAddressesAsync(userId);            

            return View(allOwnedAddresses);
        }

        [HttpPost]
        public IActionResult ChooseAddress(int SelectedAddressId)
        {           
            return RedirectToAction(nameof(CommunityTopics), new { addressId = SelectedAddressId});            
        }

        [HttpGet]
        public async Task<IActionResult> CommunityTopics(int addressId)
        {
            var communityTopics = await this.ownerService.GetAllTopicsForAddressAsync(addressId);
            return View(communityTopics);
        }

        [HttpGet]
        public async Task<IActionResult> AddAddress()
        {
            var addAddress = new AddAddressViewModel();
            addAddress.LocalityTypeViews = await this.ownerService.GetAllLocalityTypesAsync();
            addAddress.LocationTypeViews = await this.ownerService.GetAllLocationTypesAsync();

            return View(addAddress);
        }

        public async Task<IActionResult> AddAddress(AddAddressViewModel model)
        {
            //TODO: Switch redirection!
            return RedirectToAction(nameof(Index));
        }
    }
}
