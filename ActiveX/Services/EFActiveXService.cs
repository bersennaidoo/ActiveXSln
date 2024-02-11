using ActiveX.Infrastructure.PGSQLDbContext;
using ActiveX.Models.Data;
using ActiveX.Models;

namespace ActiveX.Services;

public class EFActiveXService : IActiveXService
{
    private PGSQLDbContext context;

    public EFActiveXService(PGSQLDbContext context)
    {
        context = context;
    }

    public IQueryable<Product> Products => context.Products;
}
