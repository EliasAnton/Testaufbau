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
    private readonly ArticleDbContext _articleDbContext;

    public RestController(ArticleDbContext articleDbContext)
    {
        _articleDbContext = articleDbContext;
    }

    [HttpGet("articles")]
    public ActionResult GetArticles(int take = 10, string? filter = null)
    {
        IQueryable<Article> query = _articleDbContext.Articles!;

        if (!string.IsNullOrEmpty(filter))
        {
            // Assuming filter is comma-separated list of property names to include
            var propertiesToInclude = filter.Split(',');

            query = query.Select(article => new Article
            {
                Name = propertiesToInclude.Contains("Name") ? article.Name : null,
                Description = propertiesToInclude.Contains("Description") ? article.Description : null
            });
        }

        query = query.Take(take);

        return Ok(query.ToList());
    }

    [HttpGet("articlesWithPrice")]
    public ActionResult ArticlesWithPrice(int take = 10)
    {
        return Ok(_articleDbContext.Articles!.Include(a => a.Price).Take(take).ToList());
    }

    [HttpGet("articles/sku/{sku:int}")]
    public ActionResult GetArticleBySku(int sku)
    {
        return Ok(_articleDbContext.Articles!
            .FirstOrDefault(a => a.Sku == sku));
    }

    [HttpGet("prices/{id:int}")]
    public ActionResult GetPrice(int id)
    {
        return Ok(_articleDbContext.Prices!
            .FirstOrDefault(p => p.Id == id));
    }
}