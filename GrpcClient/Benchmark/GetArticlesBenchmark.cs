using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

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

    public List<int> AmountList => new()
    {
        1,
        10,
        100,
        1000,
        10000,
        100000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfArticles { get; set; }

    [Benchmark]
    public async Task<List<Article>> GetArticles()
    {
        var articles =  await _grpcService.GetArticlesAsync(new GrpcTakeRequest { Take = NumberOfArticles });
        return articles.Articles;

    }
    
    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPrice()
    {
        var articles = await _grpcService.GetArticlesAsync(new GrpcTakeRequest { Take = NumberOfArticles });
        foreach (var article in articles.Articles!)
        {
            var price = await _grpcService.GetPriceByIdAsync(new GrpcIntRequest { IntToProcess = article.PriceId });
            article.Price = price;
        }

        return articles.Articles;
    }
}