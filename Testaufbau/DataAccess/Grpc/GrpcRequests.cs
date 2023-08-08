using ProtoBuf;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class GrpcIntRequest
{
    [ProtoMember(1)]
    public int IntToProcess { get; set; }
}

[ProtoContract]
public class GrpcTakeRequest
{
    [ProtoMember(1)]
    public int Take { get; set; }
}

[ProtoContract]
public class GrpcTakeRequestWithFilter
{
    [ProtoMember(1)]
    public int Take { get; set; }
    
    [ProtoMember(2)]
    public string? Filter { get; set; }
}