using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.UI.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
