using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using SerializationBenchmarks.Models;
using Testaufbau.DataAccess.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationBenchmarks.Json;

public class JsonSerialDeserialBenchmark
{
    private readonly Article _article;
    private readonly string _serializedPersonNsj;
    private readonly string _serializedPersonStj;

    public JsonSerialDeserialBenchmark()
    {
        _article = new Article
        {
            Id = 1,
            Name = "Chair",
            Sku = 123456,
            Description = "You can sit on it.",
            PriceId = 1,
            IsActive = true,
            Color = "black",
            Width = 0.3m,
            Height = 1.5m,
            Depth = 0.3m,
            Weight = 2.5m,
            Material = "Wood"
            
        };

        //NewtonsoftJson
        _serializedPersonNsj = JsonConvert.SerializeObject(_article);

        //System.Text.Json
        _serializedPersonStj = JsonSerializer.Serialize(_article);
    }


    [Benchmark]
    public void SerializeJsonStj()
    {
        JsonSerializer.Serialize(_article);
    }

    [Benchmark]
    public void SerializeJsonNsj()
    {
        JsonConvert.SerializeObject(_article);
    }


    [Benchmark]
    public void DeserializeJsonStj()
    {
        JsonSerializer.Deserialize<Article>(_serializedPersonStj);
    }


    [Benchmark]
    public void DeserializeJsonNsj()
    {
        JsonConvert.DeserializeObject<Article>(_serializedPersonNsj);
    }
}