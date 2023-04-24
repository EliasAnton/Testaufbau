using Testaufbau.DataAccess.Grpc;

namespace GrpcService.Services;

public class GreeterService : IGreeterService
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public Task<HelloReply> SayHelloAsync(HelloRequest request)
    {
        return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
    }
}