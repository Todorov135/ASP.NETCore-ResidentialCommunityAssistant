namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Extensions;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using System.Security.Claims;

    public class HomeManagerController : BaseController
    {
        private const string constClaimName = "HomeManagerOfAddresses";

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ExtendedUser> userManager;
        private readonly IOwnerService ownerService;
        private readonly IHomeManagerService homeMangerService;

        public HomeManagerController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ExtendedUser> userManager,
            IHomeManagerService homeMangerService,
            IOwnerService ownerService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.homeMangerService = homeMangerService;
            this.ownerService = ownerService;
        }
            

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddAddress()
        {
            var addAddress = new AddAddressViewModel();
            addAddress.LocalityTypeViews = await this.ownerService.GetAllLocalityTypesAsync();
            addAddress.LocationTypeViews = await this.ownerService.GetAllLocationTypesAsync();

            return View(addAddress);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.LocalityTypeViews = await this.ownerService.GetAllLocalityTypesAsync();
                model.LocationTypeViews = await this.ownerService.GetAllLocationTypesAsync();

                return View(model);
            }

            var user = await GetIdentityUser(User.Id());

            if (user != null && model != null)
            {
               int addressId = await homeMangerService.AddAddressAsync(model);

                string claimName = constClaimName;
                string claimValue = addressId.ToString();

                var allUserClaims = await userManager.GetClaimsAsync(user);
                var existingClaim = allUserClaims.FirstOrDefault(c =>c.Type == claimName);
                await this.ownerService.AddAddressToUserAsync(this.User.Id(), addressId);

                if (existingClaim != null)
                {
                    string newClaimList = string.Empty;
                    newClaimList += $"{existingClaim.Value}, {claimValue}";
                    var replaceClaim = new Claim(claimName, newClaimList);
                    var result = await userManager.ReplaceClaimAsync(user, existingClaim, replaceClaim);
                }
                else
                {
                    var newClaim = new Claim(claimName, claimValue);
                    var result = await userManager.AddClaimAsync(user, newClaim);
                }
                if(!this.User.IsInRole("HomeManager"))
                {
                    await userManager.AddToRoleAsync(user, "HomeManager");
                }

                await this.homeMangerService.BecomeHomeManagerAsync(this.User.Id(), addressId);                 

                return RedirectToAction(nameof(AddAddressSpecifics));
            }

            return RedirectToAction("ChooseAddress", "Owner");
        }

        [HttpGet]
        [Authorize(Roles = "HomeManager")]
        public IActionResult AddAddressSpecifics()
        {
            var apartamentsToAdd = new AllApartamentsToAddViewModel();           

            return View(apartamentsToAdd);
        }

        [HttpPost]
        [Authorize(Roles = "HomeManager")]
        public async Task<IActionResult> AddAddressSpecifics(AllApartamentsToAddViewModel apartamentsToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View(apartamentsToAdd);
            }
            
            var user = await GetIdentityUser(this.User.Id());
            var claims = await userManager.GetClaimsAsync(user);
            var addressClaim = claims.FirstOrDefault(c => c.Type == constClaimName);
            var lastClaim = addressClaim?.Value.Split(", ").LastOrDefault();

            if (lastClaim == null)
            {
                return View(apartamentsToAdd);
            }

            int addressId = int.Parse(lastClaim);
            var newApartamentToAdd = apartamentsToAdd.CurrentApartamentToAdd;
            if (newApartamentToAdd != null)
            {
                newApartamentToAdd.AddressId = addressId;
                await this.homeMangerService.AddApartamentAsync(newApartamentToAdd);
            }
            

            apartamentsToAdd.AllAddedApartaments = await this.homeMangerService.GetAllApartamentsInSpecificAddressAsync(addressId);  

            return View(apartamentsToAdd);
        }

        [HttpGet]
        [Authorize(Roles = "HomeManager")]
        public async Task<IActionResult> EditApartament(int id)
        {
            var apartamentToEdit = await this.homeMangerService.GetApartamentByIdAsync(id);
            return View(apartamentToEdit);
        }

        [HttpPost]
        [Authorize(Roles = "HomeManager")]
        public async Task<IActionResult> EditApartament(ApartamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.homeMangerService.EditApartament(model);

            return RedirectToAction("AllApartaments", "Owner");
        }

        [HttpGet]
        [Authorize(Roles = "HomeManager")]
        public IActionResult RemoveUserFromAddress(int apartamentId)
        {
            this.homeMangerService.RemoveUserFromAddress(apartamentId);

            return RedirectToAction("AllApartaments", "Owner");
        }

        [HttpGet]
        public async Task<IActionResult> SendRequestToHomeManager(int addressId, int apartamentId)
        {
            var userId = this.User.Id();
            string homeManagerOfCurrentAddress = await this.homeMangerService.GetHomeManagerIdAsync(addressId);

            if (homeManagerOfCurrentAddress == string.Empty)
            {
                return View("Error");
            }

            await this.homeMangerService.AddUserToApartamentApprovalAsync(homeManagerOfCurrentAddress, userId, apartamentId);

            return View();
        }

        private async Task<ExtendedUser> GetIdentityUser(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }


        
    }
}
