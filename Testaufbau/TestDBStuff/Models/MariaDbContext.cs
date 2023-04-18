using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Testaufbau.TestDBStuff.Models;

public class MariaDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public MariaDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("MariaDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Product>? Products { get; set; }
}