using AutoFixture;

namespace Testaufbau.Models;

public static class Seeder
{
    public static void Seed(this MariaDbContext mariaDbContext)
    {
        if (!mariaDbContext.Products!.Any())
        {
            Fixture fixture = new Fixture();
            fixture.Customize<Product>(product => product.Without(p => p.ProductId));
            //--- The next two lines add 100 rows to your database
            List<Product> products = fixture.CreateMany<Product>(100).ToList();
            mariaDbContext.AddRange(products);
            mariaDbContext.SaveChanges();
        }
    }
}