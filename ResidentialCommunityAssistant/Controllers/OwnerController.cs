namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Extensions;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.Owner;

    public class OwnerController : BaseController
    {
        string sessionAddressId = "SessionAddressId";

        private readonly IOwnerService ownerService;
        
        public OwnerController(
            IOwnerService ownerService,
            IHttpContextAccessor httpContext)
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
        public IActionResult ChooseAddress(int selectedAddressId)
        {
            var userId = this.User.Id();
            bool isAddressInUserList = this.ownerService.IsAddressInUsersList(userId, selectedAddressId);

            if (!isAddressInUserList)
            {
                return View("Error");
            }

            return RedirectToAction(nameof(CommunityTopics), new { addressId = selectedAddressId});            
        }

        [HttpGet]
        public async Task<IActionResult> CommunityTopics(int addressId)
        {
            HttpContext.Session.SetInt32(sessionAddressId, addressId);

            var communityTopics = await this.ownerService.GetAllTopicsForAddressAsync(addressId);
            return View(communityTopics);
        }

       

        [HttpGet]
        public async Task<IActionResult> AddAddressToUser(int id)
        {
            var userId = this.User.Id();
            bool isAddressInUserList = this.ownerService.IsAddressInUsersList(userId, id);
            if (!isAddressInUserList)
            {
                await this.ownerService.AddAddressToUserAsync(userId, id);
            }

            return RedirectToAction(nameof(CommunityTopics));
        }

        [HttpGet]
        public async Task<IActionResult> AllApartaments()
        {
            int? addressId = HttpContext.Session.GetInt32(sessionAddressId);

            if (addressId != null)
            {
                var apartaments = await this.ownerService.GetAllApartamentsAsync(addressId);
                return View(apartaments);
            }
            return View("Error");
        }
    }
}
