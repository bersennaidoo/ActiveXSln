using Microsoft.AspNetCore.Mvc;
using ActiveX.Models.Data;
using ActiveX.Models.Contracts;
using ActiveX.Models.ViewModels;

namespace ActiveX.Controllers;

public class HomeController : Controller
{
    private IProductService pService;

    public int PageSize = 4;

    public HomeController(IProductService service)
    {
        pService = service;
    }

    public ViewResult Index(string? category, int productPage = 1)
        => View(new ProductsListViewModel
        {
            Products = pService.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null
                ? pService.Products.Count()
                : pService.Products.Where(e =>
                        e.Category == category).Count()
            },
            CurrentCategory = category
        });
}

