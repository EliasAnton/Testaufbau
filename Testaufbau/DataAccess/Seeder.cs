using AutoFixture;

namespace Testaufbau.DataAccess;

public static class Seeder
{
    public static void Seed(this MariaDbContext mariaDbContext)
    {
        if (!mariaDbContext.Articles!.Any())
        {
            // Fixture fixture = new Fixture();
            // fixture.Customize<Article>(article => article.Without(a => a.Id));
            // //--- The next two lines add 100 rows to your database
            // List<Article> products = fixture.CreateMany<Article>(100).ToList();
            // mariaDbContext.AddRange(products);
            // mariaDbContext.SaveChanges();
            // Console.WriteLine("Database seeded");
        }
    }
}