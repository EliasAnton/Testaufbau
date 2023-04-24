using ProtoBuf;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[ProtoContract]
public class GrpcResponse
{
    [ProtoMember(1)]
    public List<Order> Orders { get; set; }
}