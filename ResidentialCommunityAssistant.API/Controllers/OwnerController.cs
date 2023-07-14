namespace ResidentialCommunityAssistant.API.Controllers
{
    
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.API;

    [Route("/api/apartament")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private readonly IHomeManagerService homeManagerService;

        public OwnerController(IHomeManagerService homeManagerService)
        {
            this.homeManagerService = homeManagerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddApartamentApi([FromBody] AddApartamentViewAPIModel apartamentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this.homeManagerService.AddApartamentByApiAsync(apartamentDto);

            return Ok();
        }

    }
}
