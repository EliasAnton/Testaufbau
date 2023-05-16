using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Client;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

namespace GrpcClient.Benchmark;

public class GetOrdersWithArticlesBenchmark
{
    private readonly IGrpcService _grpcService;
    private readonly OrderDbContext _orderDbContext;
    private static readonly string ConnectionString = "Server=localhost;Port=3307;Database=OrderDb;Uid=root;Pwd=SuperSecretRootPassword1234;";


    public GetOrdersWithArticlesBenchmark()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7214", new GrpcChannelOptions
        {
            MaxReceiveMessageSize = null
        });
        _grpcService = channel.CreateGrpcService<IGrpcService>();

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
    public async Task<List<Order>> GetOrdersWithArticlesAndPrices()
    {
        var orders = await _orderDbContext.Orders!
            .Include(o => o.OrderItems)
            .Take(NumberOfOrders)
            .ToListAsync();

        foreach (var order in orders)
        {
            foreach (var orderItem in order.OrderItems!)
            {
                var article =
                    await _grpcService.GetArticleBySkuAsync(new GrpcIntRequest { IntToProcess = orderItem.ArticleSku });
                var price = await _grpcService.GetPriceByIdAsync(new GrpcIntRequest { IntToProcess = article!.PriceId });
                article!.Price = price;
                orderItem.Article = article;
            }
        }

        return orders;
    }
}