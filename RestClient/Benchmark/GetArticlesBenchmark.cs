using System.Net.Http.Headers;
using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using Testaufbau.DataAccess.Models;

namespace RestClient.Benchmark;

public class GetArticlesBenchmark
{
    private readonly HttpClient _client = new();

    public GetArticlesBenchmark()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
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
        var articles = await _client.GetAsync($"https://localhost:7123/Rest/Articles?take={NumberOfArticles}");
        return (await articles.Content.ReadFromJsonAsync<List<Article>>())!;

    }
    
    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPrice()
    {
        var articles = await _client.GetAsync($"https://localhost:7123/Rest/Articles?take={NumberOfArticles}");
        var articleList = await articles.Content.ReadFromJsonAsync<List<Article>>();
        foreach (var article in articleList!)
        {
            var price = await _client.GetAsync($"https://localhost:7123/Rest/prices/{article.PriceId}");
            article.Price = await price.Content.ReadFromJsonAsync<Price>();
        }

        return articleList;
    }
}