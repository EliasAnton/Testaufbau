using System.Net.Http.Headers;
using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using Testaufbau.DataAccess.Models;

namespace RestClient.Benchmark;

public class GetOrdersWithOrderItemsBenchmark
{
    private readonly HttpClient _client = new();

    public GetOrdersWithOrderItemsBenchmark()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
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
    public async Task<List<Order>> GetOrders()
    {
        var response = await _client.GetAsync($"https://localhost:7123/Rest/orders?take={NumberOfOrders}");
        var orderList = response.Content.ReadFromJsonAsync<List<Order>>().Result;
        foreach (var order in orderList!)
        {
            var orderItemResponse = await _client.GetAsync($"https://localhost:7123/Rest/orderItems/{order.Id}");
            order.OrderItems = orderItemResponse.Content.ReadFromJsonAsync<List<OrderItem>>().Result;
        }

        return orderList;
    }
}