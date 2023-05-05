using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;

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
    public Task<HttpResponseMessage> GetArticles()
    {
        return _client.GetAsync($"https://localhost:7123/Rest/Articles?take={NumberOfArticles}");
    }
}