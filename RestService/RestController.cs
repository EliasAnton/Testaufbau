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
    public ActionResult GetArticles(int take = 10)
    {
        return Ok(_mariaDbContext.Articles!.Take(take));
    }

    [HttpGet("articles/{id:int}")]
    public ActionResult GetArticle(int id)
    {
        return Ok(_mariaDbContext.Articles!
            .FirstOrDefault(a => a.Id == id));
    }

    [HttpGet("articles/all")]
    public ActionResult GetAllArticles()
    {
        return Ok(_mariaDbContext.Articles!.ToList());
    }

    [HttpGet("orders")]
    public ActionResult GetOrders(int take = 10)
    {
        return Ok(_mariaDbContext.Orders!
            .Take(take));
    }


    [HttpGet("orders/{id:int}")]
    public ActionResult GetOrder(int id)
    {
        return Ok(_mariaDbContext.Orders!
            .FirstOrDefault(o => o.Id == id));
    }

    [HttpGet("orders/all")]
    public ActionResult GetAllOrders()
    {
        return Ok(_mariaDbContext.Orders!
            .ToList());
    }
    
    [HttpGet("orderItems/{orderId:int}")]
    public ActionResult GetOrderItems(int orderId)
    {
        return Ok(_mariaDbContext.OrderItems!
            .Where(o => o.OrderId == orderId));
    }

    [HttpGet("addresses/{id:int}")]
    public ActionResult GetAddress(int id)
    {
        return Ok(_mariaDbContext.Addresses!
            .FirstOrDefault(a => a.Id == id));
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