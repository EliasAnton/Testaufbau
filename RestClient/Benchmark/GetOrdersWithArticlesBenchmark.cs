using System.Net.Http.Headers;
using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace RestClient.Benchmark;

public class GetOrdersWithArticlesBenchmark
{
    private readonly HttpClient _client = new();
    
    //Port 5001 wenn service unter publish läuft, 7123 wenn über IDE
    private readonly string _port = "5001";

    private readonly OrderDbContext _orderDbContext;

    private static readonly string ConnectionString = "Server=localhost;Port=3307;Database=OrderDb;Uid=root;Pwd=SuperSecretRootPassword1234;";
    public GetOrdersWithArticlesBenchmark()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

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
                var articleResponse =
                    await _client.GetAsync($"https://localhost:{_port}/Rest/articles/sku/{orderItem.ArticleSku}");
                var article = await articleResponse.Content.ReadFromJsonAsync<Article>()!;
                var priceResponse = await _client.GetAsync($"https://localhost:{_port}/Rest/prices/{article!.PriceId}");
                article!.Price = await priceResponse.Content.ReadFromJsonAsync<Price>();
                orderItem.Article = article;
            }
        }

        return orders;
    }
}