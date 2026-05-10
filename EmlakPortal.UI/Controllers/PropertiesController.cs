using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class PropertiesController : Controller
{
    public IActionResult Create()
    {
        return View();

    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Details(int id)
    {
        ViewBag.PropertyId = id;
        return View();
    }
    public IActionResult MyProperties()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.PropertyId = id;
        return View();
    }
}