using ProtoBuf;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class GrpcIdRequest
{
    [ProtoMember(1)]
    public int Id { get; set; }
}

[ProtoContract]
public class GrpcArticlesRequest
{
    [ProtoMember(1)]
    public int Take { get; set; }
}