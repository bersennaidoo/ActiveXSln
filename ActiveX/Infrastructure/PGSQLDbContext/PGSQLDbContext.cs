using Microsoft.EntityFrameworkCore;
using ActiveX.Models.Data;

namespace ActiveX.Infrastructure.PGSQLDbContext;

public class PGSQLDbContext : DbContext 
{
    public PGSQLDbContext(DbContextOptions<PGSQLDbContext> options)
        : base(options) {}

    public DbSet<Product> Products => Set<Product>();
}
