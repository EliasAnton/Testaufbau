using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Testaufbau.DataAccess.Grpc;

namespace GrpcClient.Benchmark;

public class GetArticlesBenchmark
{
    private readonly IGrpcService _grpcService;

    public GetArticlesBenchmark()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7214", new GrpcChannelOptions
        {
            MaxReceiveMessageSize = null
        });
        _grpcService = channel.CreateGrpcService<IGrpcService>();
    }

    public List<int> _numberOfArticles => new()
    {
        1,
        10,
        100,
        1000,
        10000,
        100000
    };

    [ParamsSource(nameof(_numberOfArticles))]
    public int NumberOfArticles { get; set; }

    [Benchmark]
    public async Task<GrpcArticlesResponse> GetArticles()
    {
        return await _grpcService.GetArticlesAsync(new GrpcTakeRequest { Take = NumberOfArticles });
    }
}