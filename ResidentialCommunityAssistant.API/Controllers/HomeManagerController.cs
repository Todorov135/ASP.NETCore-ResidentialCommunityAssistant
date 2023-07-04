namespace ResidentialCommunityAssistant.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;

    public class HomeManagerController : ControllerBase
    {
        private readonly IHomeManagerService homeManagerService;

        public HomeManagerController(IHomeManagerService homeManagerService)
        {
            this.homeManagerService = homeManagerService;
        }

        public async Task<IActionResult> AddApartamentApi()
        {

            return  Ok();
        }
    }
}
