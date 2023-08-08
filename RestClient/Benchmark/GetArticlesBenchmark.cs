using System.Net.Http.Headers;
using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using Testaufbau.DataAccess.Models;

namespace RestClient.Benchmark;

public class GetArticlesBenchmark
{
    private readonly HttpClient _client = new();
    //Port 5001 wenn service unter publish läuft, 7123 wenn über IDE
    private readonly string _port = "5001";

    public GetArticlesBenchmark()
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
        10000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfArticles { get; set; }

    [Benchmark]
    public async Task<List<Article>> GetArticles()
    {
        var articles = await _client.GetAsync($"https://localhost:{_port}/Rest/Articles?take={NumberOfArticles}");
        return (await articles.Content.ReadFromJsonAsync<List<Article>>())!;
    }

    [Benchmark]
    public async Task<List<Article>> GetReducedArticles()
    {

        //so werden nur die not-nullable attribute zurück gegeben
        var filter = "NoNullableAttributes";
        var articles = await _client.GetAsync($"https://localhost:{_port}/Rest/Articles?take={NumberOfArticles}&filter={filter}");
        return (await articles.Content.ReadFromJsonAsync<List<Article>>())!;

    }

    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPriceChatty()
    {
        var articles = await _client.GetAsync($"https://localhost:{_port}/Rest/Articles?take={NumberOfArticles}");
        var articleList = await articles.Content.ReadFromJsonAsync<List<Article>>();
        foreach (var article in articleList!)
        {
            var price = await _client.GetAsync($"https://localhost:{_port}/Rest/prices/{article.PriceId}");
            article.Price = await price.Content.ReadFromJsonAsync<Price>();
        }

        return articleList;
    }

    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPriceBulky()
    {
        var articlesWithPrice = await _client.GetAsync($"https://localhost:{_port}/Rest/ArticlesWithPrice?take={NumberOfArticles}");
        return (await articlesWithPrice.Content.ReadFromJsonAsync<List<Article>>())!;
    }
}