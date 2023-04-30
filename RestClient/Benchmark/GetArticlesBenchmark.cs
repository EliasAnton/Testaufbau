using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;

namespace RestClient.Benchmark;

public class GetArticlesBenchmark
{
    private readonly HttpClient _client = new HttpClient();

    public List<int> _numberOfArticles => new List<int>
    {
        1,
        10,
        100,
        1000,
        10000,
        100000
    };
    
    public GetArticlesBenchmark()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    [ParamsSource(nameof(_numberOfArticles))]
    public int NumberOfArticles { get; set; }
    
    [Benchmark]
    public Task<HttpResponseMessage> GetArticles() => _client.GetAsync($"https://localhost:7123/Rest/Articles?take={NumberOfArticles}");

}