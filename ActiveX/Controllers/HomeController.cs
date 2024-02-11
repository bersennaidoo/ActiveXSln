using Microsoft.AspNetCore.Mvc;

namespace ActiveX.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}

