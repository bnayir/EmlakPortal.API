using Microsoft.AspNetCore.Mvc;

public class PropertiesController : Controller
{
    public IActionResult Create()
    {
        return View();

    }

    public IActionResult Details(int id)
    {
        ViewBag.PropertyId = id; // ID'yi sayfaya taşıyoruz ki AJAX ile veriyi çekebilelim
        return View();
    }
    public IActionResult MyProperties()
    {
        return View();
    }
}