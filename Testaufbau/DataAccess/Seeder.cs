using AutoFixture;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public static class Seeder
{
    public static void Seed(this MariaDbContext mariaDbContext)
    {
        if (!mariaDbContext.Articles!.Any())
        {
            var fixture = new Fixture();
            fixture.Customize<Article>(article => article.Without(a => a.Id));
            //The next two lines add 100.000 rows to the database
            var products = fixture.CreateMany<Article>(100000).ToList();
            mariaDbContext.AddRange(products);
            mariaDbContext.SaveChanges();
            Console.WriteLine("Database seeded");
        }
    }
}