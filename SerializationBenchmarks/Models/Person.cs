using ProtoBuf;

namespace SerializationBenchmarks.Models;

[ProtoContract]
public class Person
{
    [ProtoMember(1)]
    public string FirstName { get; set; }

    [ProtoMember(2)]
    public string LastName { get; set; }

    [ProtoMember(3)]
    public List<String> Emails { get; set; }
}