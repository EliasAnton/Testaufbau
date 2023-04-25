using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
public class Address
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Street { get; set; }

    [ProtoMember(3)]
    public int HouseNumber { get; set; }

    [ProtoMember(4)]
    public string ZipCode { get; set; }

    [ProtoMember(5)]
    public string City { get; set; }

    [ProtoMember(6)]
    public string Country { get; set; }
}