using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace DataAccessBenchmarks.Benchmarks;

public class GetOrdersWithOrderItemsBenchmark
{
    private readonly OrderDbContext _orderDbContext;

    private static readonly string ConnectionString = "Server=localhost;Port=3307;Database=OrderDb;Uid=root;Pwd=SuperSecretRootPassword1234;";
    public GetOrdersWithOrderItemsBenchmark()
    {
        var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
                .Options;
        _orderDbContext = new OrderDbContext(options);
    }

    public static List<int> AmountList => new()
    {
        1,
        10,
        100,
        1000,
        10000
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