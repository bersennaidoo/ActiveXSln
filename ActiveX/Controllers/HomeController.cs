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

    public ViewResult Index(int productPage = 1)
        => View(new ProductsListViewModel
        {
            Products = pService.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = pService.Products.Count()
            }
        });
}

