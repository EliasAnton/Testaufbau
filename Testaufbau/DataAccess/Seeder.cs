using AutoFixture;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public static class Seeder
{
    public static void SeedForArticleTest(this ArticleDbContext articleDbContext)
    {
        if (!articleDbContext.Articles!.Any())
        {
            var fixture = new Fixture();
            fixture.Customize<Article>(article => article.Without(a => a.Id));
            //The next two lines add 100.000 rows to the database
            var products = fixture.CreateMany<Article>(100000).ToList();
            articleDbContext.AddRange(products);
            articleDbContext.SaveChanges();
            Console.WriteLine("Database seeded with 100.000 articles");

        }
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
        fixture.Customize<Article>(article => article.Without(a => a.Id));
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
        var changes = orderDbContext.SaveChanges();

        Console.WriteLine("Database seeded with " + changes + " OrderItems");
    }
}