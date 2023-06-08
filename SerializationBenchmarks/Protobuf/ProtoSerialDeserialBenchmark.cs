using BenchmarkDotNet.Attributes;
using ProtoBuf;
using Testaufbau.DataAccess.Models;

namespace SerializationBenchmarks.Protobuf;

public class ProtoSerialDeserialBenchmark
{
    private readonly Article _article;
    private readonly byte[] _serializedArticle;

    public ProtoSerialDeserialBenchmark()
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

        using var memoryStream = new MemoryStream();
        Serializer.Serialize(memoryStream, _article);
        _serializedArticle = memoryStream.ToArray();
    }

    [Benchmark]
    public void SerializeGrpc()
    {
        using (var memoryStream = new MemoryStream())
        {
            Serializer.Serialize(memoryStream, _article);
        }
    }

    [Benchmark]
    public void DeserializeGrpc()
    {
        Serializer.Deserialize<Article>(new MemoryStream(_serializedArticle));
    }
}