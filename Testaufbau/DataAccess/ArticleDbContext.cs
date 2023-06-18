using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public class ArticleDbContext : DbContext, IArticleDbContext
{
    private readonly IConfiguration _configuration;

    public ArticleDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Article>? Articles { get; set; }
    public DbSet<Price>? Prices { get; set; }
    public Task<IDictionary<int, Price>> GetPricesByIdAsync(IEnumerable<int> priceIds)
    {
         return Task.FromResult<IDictionary<int, Price>>(Prices!.Where(x => priceIds.Contains(x.Id)).ToDictionary(x => x.Id, x => x));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Article>().HasData(
        //     new Article { Id = 1, Name = "Test1", Price = 1.0m, Sku = "Test1", ArticleCategory = ArticleCategory.Clothing },
        //     new Article { Id = 2, Name = "Test2", Price = 2.0m, Sku = "Test2", ArticleCategory = ArticleCategory.Clothing },
        //     new Article { Id = 3, Name = "Test3", Price = 3.0m, Sku = "Test3", ArticleCategory = ArticleCategory.Electronics },
        //     new Article { Id = 4, Name = "Test4", Price = 4.0m, Sku = "Test4", ArticleCategory = ArticleCategory.Electronics },
        //     new Article { Id = 5, Name = "Test5", Price = 5.0m, Sku = "Test5", ArticleCategory = ArticleCategory.Footware },
        //     new Article { Id = 6, Name = "Test6", Price = 6.0m, Sku = "Test6", ArticleCategory = ArticleCategory.Footware },
        //     new Article { Id = 7, Name = "Test7", Price = 7.0m, Sku = "Test7", ArticleCategory = ArticleCategory.Footware },
        //     new Article { Id = 8, Name = "Test8", Price = 8.0m, Sku = "Test8", ArticleCategory = ArticleCategory.Household }
        // );
        //
        // modelBuilder.Entity<Order>().HasData(
        //     new Order { Id = 1, OrderDate = DateTime.Now, TotalPrice = 1.0m, CustomerName = "Test1", CustomerEmail = "", CustomerPhone = "" }
        // );
        //
        // modelBuilder.Entity<OrderItem>().HasData(
        //     new OrderItem { Id = 1, OrderId = 1, ArticleId = 5, Quantity = 2 }
        // );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("ArticleDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}