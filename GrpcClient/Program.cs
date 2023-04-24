using Grpc.Net.Client;
using GrpcService;
using GrpcService.Protos;
using GrpcService.Services;
using ProtoBuf.Grpc.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7214");
var greeterService = channel.CreateGrpcService<IGreeterService>();

Console.WriteLine("Wie heist du?");
var message = Console.ReadLine();

var reply = await greeterService.SayHelloAsync(new HelloRequest
{
    Name = message!
});

Console.WriteLine("Greeting: " + reply.Message);

Console.WriteLine("Shutting down");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();