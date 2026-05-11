using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Messages()
        {
            return View();
        }
    }
}