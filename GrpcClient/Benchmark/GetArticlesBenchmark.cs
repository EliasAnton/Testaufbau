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
        //port 7214 wenn service von ide ausgeführt wird, 5001 wenn über publish
        var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
        {
            MaxReceiveMessageSize = null,
            HttpHandler = new SocketsHttpHandler
            {
                EnableMultipleHttp2Connections = true
            }
        });
        _grpcService = channel.CreateGrpcService<IGrpcService>();
    }

    public List<int> AmountList => new()
    {
        1,
        10,
        100,
        1000,
        10000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfArticles { get; set; }

    [Benchmark]
    public async Task<List<Article>> GetArticles()
    {
        var articles = await _grpcService.GetArticles(new GrpcTakeRequestWithFilter { Take = NumberOfArticles });
        return articles.Articles;
    }

    [Benchmark]
    public async Task<List<Article>> GetReducedArticles()
    {
        //so werden nur die not-nullable attribute zurück gegeben
        var articles = await _grpcService.GetArticles(new GrpcTakeRequestWithFilter { Take = NumberOfArticles, Filter = "NoNullableAttributes" });
        return articles.Articles;
    }

    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPriceChatty()
    {
        var articles = await _grpcService.GetArticles(new GrpcTakeRequestWithFilter { Take = NumberOfArticles });
        foreach (var article in articles.Articles!)
        {
            var price = await _grpcService.GetPriceById(new GrpcIntRequest { IntToProcess = article.PriceId });
            article.Price = price;
        }

        return articles.Articles;
    }

    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPriceBulky()
    {
        var response = await _grpcService.GetArticlesWithPrice(new GrpcTakeRequest { Take = NumberOfArticles });
        return response.Articles;
    }
}