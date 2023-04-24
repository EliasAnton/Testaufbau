using ProtoBuf;

namespace GrpcService.Protos;

[ProtoContract]
public class HelloRequest
{
    [ProtoMember(1)]
    public string Name { get; set; }
}