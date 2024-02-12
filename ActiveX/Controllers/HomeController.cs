using Microsoft.AspNetCore.Mvc;
using ActiveX.Models.Data;
using ActiveX.Models.Contracts;

namespace ActiveX.Controllers;

public class HomeController : Controller
{
    private IProductService pService;

    public int PageSize = 4;

    public HomeController(IProductService service)
    {
        pService = service;
    }

    public IActionResult Index(int productPage = 1) 
        => View(pService.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize));
}

