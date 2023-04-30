using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtoBuf;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace RestService;

[ApiController]
[Route("[controller]")]
public class RestController : ControllerBase
{
    private readonly MariaDbContext _mariaDbContext;

    public RestController(MariaDbContext mariaDbContext)
    {
        _mariaDbContext = mariaDbContext;
    }

    [HttpGet("articles")]
    public ActionResult Get(int take = 10)
    {
        return Ok(_mariaDbContext.Articles!.Take(take));
    }

    [HttpGet("articles/all")]
    public ActionResult GetAllArticles()
    {
        return Ok(_mariaDbContext.Articles!.ToList());
    }

    [HttpGet("orders")]
    public ActionResult GetOrders()
    {
        return Ok(_mariaDbContext.Orders!
            .Include(o => o.OrderItems)!
            .ThenInclude(oi => oi.Article)
            .Include(o => o.CustomerAddress)
            .ToList());
    }


    [HttpPost("articles/update")]
    public ActionResult UpdateArticle(Article article)
    {
        _mariaDbContext.Articles!.Update(article);
        _mariaDbContext.SaveChanges();
        return Ok();
    }

    [HttpGet("grpc/test")]
    public ActionResult GrpcTest()
    {
        using (var file = System.IO.File.Create("test.buf"))
        {
            Serializer.Serialize(file,
                new Article
                {
                    Id = 1,
                    Name = "Rankobelisk",
                    ArticleCategory = ArticleCategory.Clothing,
                    Description = "Test",
                    Price = 1,
                    Sku = "Test"
                });
            Console.WriteLine("Serialized");
        }

        using (var fileStream = System.IO.File.OpenRead("test.buf"))
        {
            var article = Serializer.Deserialize<Article>(fileStream);
            Console.WriteLine("Deserialized " + article.Name);
        }

        return Ok();
    }
}