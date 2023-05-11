using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace DataAccessBenchmarks.Benchmarks;

public class GetOrdersWithOrderItemsBenchmark
{
    private readonly OrderDbContext _orderDbContext;

    public GetOrdersWithOrderItemsBenchmark(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
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
        var orders = await _orderDbContext.Orders!
            .Include(o => o.OrderItems)
            .Take(NumberOfOrders)
            .ToListAsync();
        return orders;
    }
}