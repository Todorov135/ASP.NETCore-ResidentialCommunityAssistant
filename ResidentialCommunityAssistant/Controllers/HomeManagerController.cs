namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using NuGet.Packaging.Signing;
    using ResidentialCommunityAssistant.Extensions;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.HomeManager;
    using System.Diagnostics;
    using System.Security.Claims;

    public class HomeManagerController : BaseController
    {
        private string constClaimName = "HomeManagerOfAddresses";

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IOwnerService ownerService;
        private readonly IHomeManagerService homeMangerService;

        public HomeManagerController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            IHomeManagerService homeMangerService,
            IOwnerService ownerService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.homeMangerService = homeMangerService;
            this.ownerService = ownerService;
        }

        public IActionResult Index()
        {
            return View();
        }
              

        [HttpGet]
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
            int addressId = 0;

            if (user != null && model != null)
            {
                addressId = await homeMangerService.AddAddressAsync(model);

                string claimName = constClaimName;
                string claimValue = addressId.ToString();

                var allUserClaims = await userManager.GetClaimsAsync(user);
                var existingClaim = allUserClaims.FirstOrDefault(c =>c.Type == claimName);


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
                            

                return RedirectToAction(nameof(AddAddressSpecifics));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddAddressSpecifics()
        {
            var apartamentsToAdd = new AllApartamentsToAddViewModel();           

            return View(apartamentsToAdd);
        }

        [HttpPost]
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

        private async Task<IdentityUser> GetIdentityUser(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }
    }
}
