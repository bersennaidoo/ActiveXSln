using System.Text.Json.Serialization;
using ActiveX.Infrastructure;

namespace ActiveX.Models.Data;

public class SessionCart : Cart 
{
    public static Cart GetCart(IServiceProvider services)
    {
        ISession? session =
            services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;
        SessionCart cart = session?.Get<SessionCart>("Cart")
            ?? new SessionCart();
        cart.Session = session;
        return cart;
    }

    [JsonIgnore]
    public ISession? Session { get; set; }

    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.Set<SessionCart>("Cart", this);
    }

    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.Set<SessionCart>("Cart", this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("Cart");
    }
}
