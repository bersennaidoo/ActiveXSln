using Microsoft.AspNetCore.Mvc;
using ActiveX.Models.Contracts;

namespace ActiveX.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IProductService pService;

    public NavigationMenuViewComponent(IProductService service)
    {
        pService = service;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(pService.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
    }
}
