using Microsoft.EntityFrameworkCore;

namespace Testaufbau.TestDBStuff.Models;

public class SalesContext : DbContext
{
    public SalesContext(DbContextOptions<SalesContext> options) : base(options)
    {
    }

    public DbSet<Product>? Products { get; set; }
}