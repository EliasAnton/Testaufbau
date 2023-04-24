using ProtoBuf;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class GrpcRequest
{
    [ProtoMember(1)]
    public int Id { get; set; }
}