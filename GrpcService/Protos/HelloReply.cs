using ProtoBuf;

namespace GrpcService.Protos;

[ProtoContract]
public class HelloReply
{
    [ProtoMember(1)]
    public string Message { get; set; }
}