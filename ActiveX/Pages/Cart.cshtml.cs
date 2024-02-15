using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActiveX.Infrastructure;
using ActiveX.Models.Data;
using ActiveX.Models.Contracts;

namespace ActiveX.Pages;

public class CartModel : PageModel
{
    private IProductService pService;

    public CartModel(IProductService service, Cart cartService)
    {
        pService = service;
        Cart = cartService;
    }

    public Cart Cart { get; set; }

    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
        //Cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
    }

    public IActionResult OnPost(long productId, string returnUrl)
    {
        Product product = pService.Products
        .FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart.AddItem(product, 1);
        }
        return RedirectToPage(new { returnUrl = returnUrl });
    }

    public IActionResult OnPostRemove(long productId, string returnUrl)
    {
        Cart.RemoveLine(Cart.Lines.FirstOrDefault(cl =>
                    cl.Product.ProductID == productId).Product);

        return RedirectToPage(new { returnUrl = returnUrl });
    }
}
