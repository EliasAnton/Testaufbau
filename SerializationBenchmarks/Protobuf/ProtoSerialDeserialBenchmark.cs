using BenchmarkDotNet.Attributes;
using ProtoBuf;
using SerializationBenchmarks.Models;

namespace SerializationBenchmarks.Grpc;

public class ProtoSerialDeserialBenchmark
{
    private readonly Person _person;
    private readonly byte[] _serializedPerson;

    public ProtoSerialDeserialBenchmark()
    {
        _person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Emails = new List<string>
            {
                "asdfghj",
                "yxcvbnm"
            }
        };

        using var memoryStream = new MemoryStream();
        Serializer.Serialize(memoryStream, _person);
        _serializedPerson = memoryStream.ToArray();
    }

    [Benchmark]
    public void SerializeGrpc()
    {
        using (var memoryStream = new MemoryStream())
        {
            Serializer.Serialize(memoryStream, _person);
        }
    }

    [Benchmark]
    public void DeserializeGrpc()
    {
        Serializer.Deserialize<Person>(new MemoryStream(_serializedPerson));
    }
}