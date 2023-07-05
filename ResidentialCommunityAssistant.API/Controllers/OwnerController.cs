namespace ResidentialCommunityAssistant.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.HomeManager;

    [ApiController]
    [Route("/api/apartament")]
    public class OwnerController : ControllerBase
    {
        private readonly IHomeManagerService homeManagerService;

        public OwnerController(IHomeManagerService homeManagerService)
        {
            this.homeManagerService = homeManagerService;
        }

        [HttpPost]        
        public async Task<IActionResult> AddApartamentApi([FromBody] AddApartamentViewModel apartamentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this.homeManagerService.AddApartamentAsync(apartamentDto);
            return Ok();
        }
    }
}
