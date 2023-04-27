using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using SerializationBenchmarks.Models;

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
        _serializedPersonStj = System.Text.Json.JsonSerializer.Serialize(_person);
    }


    [Benchmark]
    public void SerializeJsonSTJ()
    {
        System.Text.Json.JsonSerializer.Serialize(_person);
    }

    [Benchmark]
    public void SerializeJsonNSJ()
    {
        JsonConvert.SerializeObject(_person);
    }


    [Benchmark]
    public void DeserializeJsonSTJ()
    {
        System.Text.Json.JsonSerializer.Deserialize<Person>(_serializedPersonStj);
    }


    [Benchmark]
    public void DeserializeJsonNSJ()
    {
        JsonConvert.DeserializeObject<Person>(_serializedPersonNsj);
    }

}