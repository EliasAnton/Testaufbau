using Microsoft.AspNetCore.Mvc;
using ProtoBuf;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace RestService;

[ApiController]
[Route("[controller]")]
public class RestController : ControllerBase
{
    private readonly ArticleDbContext _articleDbContext;

    public RestController(ArticleDbContext articleDbContext)
    {
        _articleDbContext = articleDbContext;
    }

    [HttpGet("articles")]
    public ActionResult GetArticles(int take = 10)
    {
        return Ok(_articleDbContext.Articles!.Take(take));
    }

    [HttpGet("articles/{id:int}")]
    public ActionResult GetArticleById(int id)
    {
        return Ok(_articleDbContext.Articles!
            .FirstOrDefault(a => a.Id == id));
    }
    
    [HttpGet("articles/sku/{sku:int}")]
    public ActionResult GetArticleBySku(int sku)
    {
        return Ok(_articleDbContext.Articles!
            .FirstOrDefault(a => a.Sku == sku));
    }

    [HttpGet("articles/all")]
    public ActionResult GetAllArticles()
    {
        return Ok(_articleDbContext.Articles!.ToList());
    }

    [HttpGet("prices/{id:int}")]
    public ActionResult GetPrice(int id)
    {
        return Ok(_articleDbContext.Prices!
            .FirstOrDefault(p => p.Id == id));
    }
}