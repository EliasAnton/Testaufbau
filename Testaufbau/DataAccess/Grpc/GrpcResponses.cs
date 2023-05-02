using ProtoBuf;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class GrpcOrdersResponse
{
    [ProtoMember(1)]
    public List<Order> Orders { get; set; }
}

[ProtoContract]
public class GrpcArticlesResponse
{
    [ProtoMember(1)]
    public List<Article> Articles { get; set; }
}