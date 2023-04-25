using ProtoBuf;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class GrpcIdRequest
{
    [ProtoMember(1)]
    public int Id { get; set; }
}