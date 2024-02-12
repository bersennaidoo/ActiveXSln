using Microsoft.EntityFrameworkCore;
using ActiveX.Models.Data;

namespace ActiveX.Data.Repository;

public class PGDbContext : DbContext 
{
    public PGDbContext(DbContextOptions<PGDbContext> options)
        : base(options) {}

    public DbSet<Product> Products => Set<Product>();
}
