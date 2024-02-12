using ActiveX.Models.Data;

namespace ActiveX.Models.Contracts;

public interface IProductService
{
    IQueryable<Product> Products { get; }
}
