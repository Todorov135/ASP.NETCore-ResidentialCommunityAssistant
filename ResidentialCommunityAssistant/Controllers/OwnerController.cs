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
        
        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;            
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
            HttpContext.Session.SetInt32(sessionAddressId, selectedAddressId);

            return RedirectToAction(nameof(CommunityTopics), new { addressId = selectedAddressId});            
        }

        [HttpGet]
        public async Task<IActionResult> CommunityTopics()
        {
            int sessionddressId = HttpContext.Session.GetInt32(sessionAddressId) ?? 0;
            if (sessionddressId != 0)
            {
                var communityTopics = await this.ownerService.GetAllTopicsForAddressAsync(sessionddressId);
                return View(communityTopics);
            }

            return View();
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

            return RedirectToAction(nameof(ChooseAddress));
        }

        [HttpGet]
        public async Task<IActionResult> AllApartaments(int? givenAddressId)
        {
            int? addressId;
            if (givenAddressId != null)
            {
                addressId = givenAddressId;
            }
            else
            {
               addressId = HttpContext.Session.GetInt32(sessionAddressId);
            }
             

            if (addressId != null)
            {
                var apartaments = await this.ownerService.GetAllApartamentsAsync(addressId);
                return View(apartaments);
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult AddCommunityTopic()
        {
            var communityTopic = new AddCommunityTopicViewModel();

            return View(communityTopic);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommunityTopic(AddCommunityTopicViewModel model)
        {
            int addressId = HttpContext.Session.GetInt32(sessionAddressId) ?? 0;
            model.AddressId = addressId;
            model.CreatorId = this.User.Id(); 

            if (!ModelState.IsValid || addressId == 0)
            {
                return View(model);
            }

            await this.ownerService.AddCommunityTopicAsync(model);  
            
            return RedirectToAction(nameof(CommunityTopics));
           
        }

        [HttpGet]
        public async Task<IActionResult> EditCommunityTopic(int id)
        {
            var communityTopic = await this.ownerService.GetCommunityTopicAsync(id);

            return View(communityTopic);
        }

        [HttpPost]
        public async Task<IActionResult> EditCommunityTopic(CommunityTopicViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.ownerService.EditCommunityTopic(model);

            return RedirectToAction(nameof(CommunityTopics));
        }

    }
}
