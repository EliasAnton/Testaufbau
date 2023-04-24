using GrpcService.Protos;
using ProtoBuf.Grpc.Configuration;

namespace GrpcService.Services;

[Service]
public interface IGreeterService
{
    Task<HelloReply> SayHelloAsync(HelloRequest request);
}