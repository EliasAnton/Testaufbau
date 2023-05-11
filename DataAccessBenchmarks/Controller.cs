using BenchmarkDotNet.Running;
using DataAccessBenchmarks.Benchmarks;
using Microsoft.AspNetCore.Mvc;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace DataAccessBenchmarks;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly OrderDbContext _orderDbContext;

    public Controller(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    [HttpPost("BenchmarkGetOrdersWithOrderIds")]
    public ActionResult BenchmarkGetOrdersWithOrderIds()
    {
        var summary = BenchmarkRunner.Run<GetOrdersWithOrderItemsBenchmark>();
        return Ok();
    }
}