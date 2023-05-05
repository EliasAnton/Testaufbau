using AutoFixture;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public static class Seeder
{
    public static void SeedForArticleTest(this MariaDbContext mariaDbContext)
    {
        if (!mariaDbContext.Articles!.Any())
        {
            var fixture = new Fixture();
            fixture.Customize<Article>(article => article.Without(a => a.Id));
            //The next two lines add 100.000 rows to the database
            var products = fixture.CreateMany<Article>(100000).ToList();
            mariaDbContext.AddRange(products);
            mariaDbContext.SaveChanges();
            Console.WriteLine("Database seeded with 100.000 articles");

        }
    }

    public static void SeedForOrderTest(MariaDbContext mariaDbContext)
    {
        if (!mariaDbContext.Orders!.Any())
        {
            var fixture = new Fixture();
            CustomizeModel(fixture);

            AddOrders(mariaDbContext, fixture);
            AddOrderItemsWithOrderReference(mariaDbContext, fixture);
        }
    }
    

    private static void CustomizeModel(Fixture fixture)
    {
        fixture.Customize<Order>(order => order.Without(o => o.Id));
        fixture.Customize<OrderItem>(orderItem => orderItem
            .Without(oi => oi.Id)
            .Without(oi => oi.OrderId)
        );
        fixture.Customize<Article>(article => article.Without(a => a.Id));
    }

    private static void AddOrders(MariaDbContext mariaDbContext, Fixture fixture)
    {
        //The next two lines add 100.000 rows to the database
        var products = fixture.CreateMany<Order>(100000).ToList();
        mariaDbContext.Orders?.AddRange(products);
        mariaDbContext.SaveChanges();
        
        Console.WriteLine("Database seeded with 100.000 Orders");
    }

    //fetches all orders from db and adds between 1 and 2 orderItems to them
    private static void AddOrderItemsWithOrderReference(MariaDbContext mariaDbContext, Fixture fixture)
    {
        var orders = mariaDbContext.Orders!.ToList();
        foreach (var order in orders)
        {
            Random rnd = new Random();
            var orderItems = fixture.CreateMany<OrderItem>(rnd.Next(1, 3)).ToList();
            foreach (var orderItem in orderItems)
            {
                orderItem.OrderId = order.Id;
            }
            mariaDbContext.OrderItems!.AddRange(orderItems);
            
            mariaDbContext.SaveChanges();
        
            Console.WriteLine("Database seeded with OrderItems");
        }
    }
}