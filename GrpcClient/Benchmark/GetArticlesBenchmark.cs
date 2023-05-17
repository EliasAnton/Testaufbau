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
        10000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfArticles { get; set; }

    [Benchmark]
    public List<Article> GetArticles()
    {
        var articles = _grpcService.GetArticles(new GrpcTakeRequest { Take = NumberOfArticles });
        return articles.Articles;

    }

    [Benchmark]
    public List<Article> GetReducedArticles()
    {
        //so werden nur die not-nullable attribute zurück gegeben
        var articles = _grpcService.GetArticles(new GrpcTakeRequest { Take = NumberOfArticles }, "NoNullableAttributes");
        return articles.Articles;

    }

    [Benchmark]
    public List<Article> GetArticlesWithPriceChatty()
    {
        var articles = _grpcService.GetArticles(new GrpcTakeRequest { Take = NumberOfArticles });
        foreach (var article in articles.Articles!)
        {
            var price = _grpcService.GetPriceById(new GrpcIntRequest { IntToProcess = article.PriceId });
            article.Price = price;
        }

        return articles.Articles;
    }

    [Benchmark]
    public List<Article> GetArticlesWithPriceBulky()
    {
        return _grpcService.GetArticlesWithPrice(new GrpcTakeRequest { Take = NumberOfArticles }).Articles;
    }
}