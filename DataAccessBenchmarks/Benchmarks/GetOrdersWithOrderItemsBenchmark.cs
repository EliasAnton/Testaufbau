using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace DataAccessBenchmarks.Benchmarks;

public class GetOrdersWithOrderItemsBenchmark
{
    private readonly MariaDbContext _dbContext;

    public GetOrdersWithOrderItemsBenchmark(MariaDbContext DbContext)
    {
        _dbContext = DbContext;
    }

    public static List<int> AmountList => new()
    {
        1,
        10,
        100,
        1000,
        10000,
        //100000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfOrders { get; set; }

    [Benchmark]
    public async Task<List<Order>> GetOrdersWithOrderItems()
    {
        var orders = await _dbContext.Orders!
            .Include(o => o.OrderItems)
            .Take(NumberOfOrders)
            .ToListAsync();
        return orders;
    }
}