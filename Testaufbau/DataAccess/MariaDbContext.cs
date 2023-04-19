using Microsoft.EntityFrameworkCore;
using Testaufbau.Models;

namespace Testaufbau.DataAccess;

public class MariaDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public MariaDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>().HasData(
            new Article { Id = 1, Name = "Test1", Price = 1.0m, SKU = "Test1" },
            new Article { Id = 2, Name = "Test2", Price = 2.0m, SKU = "Test2" },
            new Article { Id = 3, Name = "Test3", Price = 3.0m, SKU = "Test3" },
            new Article { Id = 4, Name = "Test4", Price = 4.0m, SKU = "Test4" },
            new Article { Id = 5, Name = "Test5", Price = 5.0m, SKU = "Test5" },
            new Article { Id = 6, Name = "Test6", Price = 6.0m, SKU = "Test6" },
            new Article { Id = 7, Name = "Test7", Price = 7.0m, SKU = "Test7" },
            new Article { Id = 8, Name = "Test8", Price = 8.0m, SKU = "Test8" }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, OrderDate = DateTime.Now, TotalPrice = 1.0m, CustomerName = "Test1", CustomerAddressId = 1, CustomerEmail = "", CustomerPhone = "" }
        );

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = 1, OrderId = 1, ArticleId = 1, Quantity = 1 }
        );

        modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, Street = "Test1", HouseNumber = 1, City = "Test1", ZipCode = "Test1", Country = "Test1" }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("MariaDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Article>? Articles { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<Address>? Addresses { get; set; }
}