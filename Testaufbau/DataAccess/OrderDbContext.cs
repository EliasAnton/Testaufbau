using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public class OrderDbContext : DbContext, IOrderDbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
        //Necessary to do it like this instead of the constructor below to be able to create
        //instances of OrderDbContext during benchmarking
    }
    
    // public OrderDbContext(IConfiguration configuration)
    // {
    //     _configuration = configuration;
    // }

    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId);

        // modelBuilder.Entity<Article>().HasData(
        //     new Article { IntToProcess = 1, Name = "Test1", Price = 1.0m, Sku = "Test1", ArticleCategory = ArticleCategory.Clothing },
        //     new Article { IntToProcess = 2, Name = "Test2", Price = 2.0m, Sku = "Test2", ArticleCategory = ArticleCategory.Clothing },
        //     new Article { IntToProcess = 3, Name = "Test3", Price = 3.0m, Sku = "Test3", ArticleCategory = ArticleCategory.Electronics },
        //     new Article { IntToProcess = 4, Name = "Test4", Price = 4.0m, Sku = "Test4", ArticleCategory = ArticleCategory.Electronics },
        //     new Article { IntToProcess = 5, Name = "Test5", Price = 5.0m, Sku = "Test5", ArticleCategory = ArticleCategory.Footware },
        //     new Article { IntToProcess = 6, Name = "Test6", Price = 6.0m, Sku = "Test6", ArticleCategory = ArticleCategory.Footware },
        //     new Article { IntToProcess = 7, Name = "Test7", Price = 7.0m, Sku = "Test7", ArticleCategory = ArticleCategory.Footware },
        //     new Article { IntToProcess = 8, Name = "Test8", Price = 8.0m, Sku = "Test8", ArticleCategory = ArticleCategory.Household }
        // );
        //
        // modelBuilder.Entity<Order>().HasData(
        //     new Order { IntToProcess = 1, OrderDate = DateTime.Now, TotalPrice = 1.0m, CustomerName = "Test1", CustomerEmail = "", CustomerPhone = "" }
        // );
        //
        // modelBuilder.Entity<OrderItem>().HasData(
        //     new OrderItem { IntToProcess = 1, OrderId = 1, ArticleId = 5, Quantity = 2 }
        // );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var connectionString = "Server=localhost;Port=3307;Database=OrderDb;Uid=root;Pwd=SuperSecretRootPassword1234;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}