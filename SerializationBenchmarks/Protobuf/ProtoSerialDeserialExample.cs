using ProtoBuf;
using SerializationBenchmarks.Models;

namespace SerializationBenchmarks.Grpc;

public class ProtoSerialDeserialExample
{
    public void GrpcRoundtripSerialization()
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

        var result = new Person();
        using (var memoryStream = new MemoryStream())
        {
            Serializer.Serialize(memoryStream, person);
            var serializedPerson = memoryStream.ToArray();

            result = Serializer.Deserialize<Person>(new MemoryStream(serializedPerson));
        }

        Console.WriteLine(result.FirstName);
        Console.WriteLine(result.LastName);
        Console.WriteLine(result.Emails[0]);
        Console.WriteLine(result.Emails[1]);
    }
}