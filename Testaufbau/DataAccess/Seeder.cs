using AutoFixture;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public static class Seeder
{
    public static void SeedForArticleTest(this ArticleDbContext articleDbContext, OrderDbContext orderDbContext)
    {
        if (!articleDbContext.Articles!.Any())
        {
            var fixture = new Fixture();
            fixture.Customize<Article>(article => article
                .Without(a => a.Id)
                .Without(a => a.Price)
                .Without(a => a.Sku));
            fixture.Customize<Price>(price => price.Without(p => p.Id));
            
            AddArticles(articleDbContext, orderDbContext, fixture);
            AddPricesToArticles(articleDbContext, fixture);
            //The next two lines add 100.000 rows to the database
            var products = fixture.CreateMany<Article>(100000).ToList();
            articleDbContext.AddRange(products);
            articleDbContext.SaveChanges();
            Console.WriteLine("Database seeded with 100.000 articles");

        }
    }

    private static void AddArticles(ArticleDbContext articleDbContext, OrderDbContext orderDbContext, Fixture fixture)
    {
        var allSkusReferencedByOrderItems = orderDbContext.OrderItems!.Select(oi => oi.ArticleSku).Distinct().ToList();
        var articlesToInsert = new List<Article>();
        foreach (var sku in allSkusReferencedByOrderItems)
        {
            var articleToInsert = fixture.Create<Article>();
            articleToInsert.Sku = sku;
            articlesToInsert.Add(articleToInsert);
        }
        articleDbContext.Articles!.AddRange(articlesToInsert);
        articleDbContext.SaveChanges();
        Console.WriteLine("Database seeded with " + articlesToInsert.Count + " articles");
    }

    private static void AddPricesToArticles(ArticleDbContext articleDbContext, Fixture fixture)
    {
        var articles = articleDbContext.Articles!.ToList();
        foreach (var article in articles)
        {
            var price = fixture.Create<Price>();
            //article.PriceId = price.Id;
            article.Price = price;
        }
        articleDbContext.SaveChanges();
        Console.WriteLine("Database seeded with prices");
    }
    
    
    
    
    public static void SeedForOrderTest(this OrderDbContext orderDbContext)
    {
        if (!orderDbContext.Orders!.Any())
        {
            var fixture = new Fixture();
            //Remove the standard throw on recursion behaviour
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            CustomizeModel(fixture);

            AddOrders(orderDbContext, fixture);
            AddOrderItemsWithOrderReference(orderDbContext, fixture);
        }
    }


    private static void CustomizeModel(Fixture fixture)
    {
        fixture.Customize<Order>(order => order
            .Without(o => o.Id)
            .Without(o => o.OrderItems));
        fixture.Customize<OrderItem>(orderItem => orderItem
            .Without(oi => oi.Id)
            .Without(oi => oi.OrderId)
            .Without(oi => oi.Order)
        );
    }

    private static void AddOrders(OrderDbContext orderDbContext, Fixture fixture)
    {
        //The next two lines add 100.000 rows to the database
        var products = fixture.CreateMany<Order>(100000).ToList();
        orderDbContext.Orders?.AddRange(products);
        orderDbContext.SaveChanges();

        Console.WriteLine("Database seeded with 100.000 Orders");
    }

    //fetches all orders from db and adds between 1 and 2 orderItems to them
    private static void AddOrderItemsWithOrderReference(OrderDbContext orderDbContext, Fixture fixture)
    {
        var orders = orderDbContext.Orders!.ToList();
        foreach (var order in orders)
        {
            Random rnd = new Random();
            var orderItems = fixture.CreateMany<OrderItem>(rnd.Next(1, 3)).ToList();
            foreach (var orderItem in orderItems)
            {
                orderItem.OrderId = order.Id;
            }
            orderDbContext.OrderItems!.AddRange(orderItems);
        }
        orderDbContext.SaveChanges();

        Console.WriteLine("Database seeded with OrderItems");
    }
}