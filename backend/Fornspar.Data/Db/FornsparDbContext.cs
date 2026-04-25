using Microsoft.EntityFrameworkCore;

namespace Fornspar.Data.Db;

public class FornsparDbContext(DbContextOptions<FornsparDbContext> options) : DbContext(options)
{
    public DbSet<Runsten> Runstens { get; set; }
}