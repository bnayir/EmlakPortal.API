using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}