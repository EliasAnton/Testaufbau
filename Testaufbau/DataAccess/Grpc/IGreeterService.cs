using ProtoBuf.Grpc.Configuration;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGreeterService
{
    Task<HelloReply> SayHelloAsync(HelloRequest request);
}