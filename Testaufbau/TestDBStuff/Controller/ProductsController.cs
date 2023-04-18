using Microsoft.AspNetCore.Mvc;
using Testaufbau.TestDBStuff.Models;

namespace Testaufbau.TestDBStuff.Controller;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly MariaDbContext _mariaDbContext;

    public ProductsController(MariaDbContext mariaDbContext)
    {
        _mariaDbContext = mariaDbContext;
    }

    [HttpGet]
    public ActionResult Get(int take = 10, int skip = 0)
    {
        return Ok(_mariaDbContext.Products!.OrderBy(p => p.ProductId).Skip(skip).Take(take));
    }
}