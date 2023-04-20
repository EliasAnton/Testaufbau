using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.Controllers;

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
    public ActionResult Get(int take = 10, int skip = 0)
    {
        return Ok(_mariaDbContext.Articles!.OrderBy(a => a.Id).Skip(skip).Take(take));
    }

    [HttpGet("articles/all")]
    public ActionResult GetAllArticles()
    {
        return Ok(_mariaDbContext.Articles!.ToList());
    }

    [HttpGet("orders")]
    public ActionResult GetOrders()
    {
        return Ok(_mariaDbContext.Orders!.Include(o => o.OrderItems).ThenInclude(o => o.Article).ToList());
    }

    [HttpPost("articles/update")]
    public ActionResult UpdateArticle(Article article)
    {
        _mariaDbContext.Articles!.Update(article);
        _mariaDbContext.SaveChanges();
        return Ok();
    }
}