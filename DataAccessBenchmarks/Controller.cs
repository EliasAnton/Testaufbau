using BenchmarkDotNet.Running;
using DataAccessBenchmarks.Benchmarks;
using Microsoft.AspNetCore.Mvc;
using Testaufbau.DataAccess;

namespace DataAccessBenchmarks;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly MariaDbContext _mariaDbContext;

    public Controller(MariaDbContext mariaDbContext)
    {
        _mariaDbContext = mariaDbContext;
    }

    [HttpPost("BenchmarkGetOrdersWithOrderIds")]
    public ActionResult BenchmarkGetOrdersWithOrderIds()
    {
        return Ok(BenchmarkRunner.Run<GetOrdersWithOrderItemsBenchmark>());
    }
}