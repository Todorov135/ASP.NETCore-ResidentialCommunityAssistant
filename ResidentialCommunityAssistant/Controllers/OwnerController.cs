namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
