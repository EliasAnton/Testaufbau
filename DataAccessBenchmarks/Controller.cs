using BenchmarkDotNet.Running;
using DataAccessBenchmarks.Benchmarks;
using Microsoft.AspNetCore.Mvc;
using Testaufbau.DataAccess;

namespace DataAccessBenchmarks;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly ArticleDbContext _articleDbContext;

    public Controller(ArticleDbContext articleDbContext)
    {
        _articleDbContext = articleDbContext;
    }

    [HttpPost("BenchmarkGetOrdersWithOrderIds")]
    public ActionResult BenchmarkGetOrdersWithOrderIds()
    {
        return Ok(BenchmarkRunner.Run<GetOrdersWithOrderItemsBenchmark>());
    }
}