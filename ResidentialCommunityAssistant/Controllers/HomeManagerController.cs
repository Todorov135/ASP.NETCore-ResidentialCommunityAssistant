namespace ResidentialCommunityAssistant.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BecomeHomeManager()
        {
            return View();
        }
    }
}
