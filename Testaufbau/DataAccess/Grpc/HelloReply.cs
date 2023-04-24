using ProtoBuf;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class HelloReply
{
    [ProtoMember(1)]
    public string Message { get; set; }
}