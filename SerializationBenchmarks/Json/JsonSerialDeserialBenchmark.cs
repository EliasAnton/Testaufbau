using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using SerializationBenchmarks.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationBenchmarks.Json;

public class JsonSerialDeserialBenchmark
{
    private readonly Person _person;
    private readonly string _serializedPersonNsj;
    private readonly string _serializedPersonStj;

    public JsonSerialDeserialBenchmark()
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

        //NewtonsoftJson
        _serializedPersonNsj = JsonConvert.SerializeObject(_person);

        //System.Text.Json
        _serializedPersonStj = JsonSerializer.Serialize(_person);
    }


    [Benchmark]
    public void SerializeJsonStj()
    {
        JsonSerializer.Serialize(_person);
    }

    [Benchmark]
    public void SerializeJsonNsj()
    {
        JsonConvert.SerializeObject(_person);
    }


    [Benchmark]
    public void DeserializeJsonSTJ()
    {
        JsonSerializer.Deserialize<Person>(_serializedPersonStj);
    }


    [Benchmark]
    public void DeserializeJsonNSJ()
    {
        JsonConvert.DeserializeObject<Person>(_serializedPersonNsj);
    }
}