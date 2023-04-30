using Newtonsoft.Json;
using SerializationBenchmarks.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationBenchmarks.Json;

public class JsonSerialDeserialExample
{
    public void SystemTextJsonSerialDeserialExample()
    {
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Emails = new List<string>
            {
                "asdfghj",
                "yxcvbnm"
            }
        };

        var serializedPerson = JsonSerializer.Serialize(person);

        var result = JsonSerializer.Deserialize<Person>(serializedPerson);

        Console.WriteLine(result.FirstName);
        Console.WriteLine(result.LastName);
        Console.WriteLine(result.Emails[0]);
        Console.WriteLine(result.Emails[1]);
    }

    public void NewtonsoftJsonSerialDeserialExample()
    {
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Emails = new List<string>
            {
                "asdfghj",
                "yxcvbnm"
            }
        };

        var serializedPerson = JsonConvert.SerializeObject(person);

        var result = JsonConvert.DeserializeObject<Person>(serializedPerson);

        Console.WriteLine(result.FirstName);
        Console.WriteLine(result.LastName);
        Console.WriteLine(result.Emails[0]);
        Console.WriteLine(result.Emails[1]);
    }
}

//Add simple .graphql model example here