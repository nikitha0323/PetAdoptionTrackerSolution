using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionTracker.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
