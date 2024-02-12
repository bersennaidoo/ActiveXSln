using ActiveX.Data.Repository;
using ActiveX.Models.Data;
using ActiveX.Models.Contracts;

namespace ActiveX.Services;

public class EFProductService : IProductService
{
    private PGDbContext context;

    public EFProductService(PGDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Product> Products => context.Products;
}
