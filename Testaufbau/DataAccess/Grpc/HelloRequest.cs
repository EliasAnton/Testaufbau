using ProtoBuf;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class HelloRequest
{
    [ProtoMember(1)]
    public string Name { get; set; }
}