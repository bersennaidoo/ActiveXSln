using ActiveX.Models.Data;

namespace ActiveX.Models;

public interface IActiveXService
{
    IQueryable<Product> Products { get; }
}
