using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

namespace GrpcClient.Benchmark;

public class GetOrdersWithOrderItemsBenchmark
{
    private readonly IGrpcService _grpcService;

    public GetOrdersWithOrderItemsBenchmark()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7214", new GrpcChannelOptions
        {
            MaxReceiveMessageSize = null
        });
        _grpcService = channel.CreateGrpcService<IGrpcService>();
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
        var response = await _grpcService.GetOrdersAsync(new GrpcTakeRequest { Take = NumberOfOrders });
        foreach (var order in response.Orders)
        {
            var orderItemResponse = await _grpcService.GetOrderItemsAsync(new GrpcIdRequest { Id = order.Id });
            order.OrderItems!.AddRange(orderItemResponse.OrderItems);
        }

        return response.Orders;
    }
}