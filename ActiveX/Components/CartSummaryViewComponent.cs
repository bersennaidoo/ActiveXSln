using Microsoft.AspNetCore.Mvc;
using ActiveX.Models.Data;

namespace ActiveX.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private Cart cart;

    public CartSummaryViewComponent(Cart cartService)
    {
        cart = cartService;
    }
    public IViewComponentResult Invoke()
    {
        return View(cart);
    }
}
