using Grpc.Net.Client;
using GrpcService;

using var channel = GrpcChannel.ForAddress("https://localhost:7214");
var client = new Greeter.GreeterClient(channel);

Console.WriteLine("Wie heist du?");
var message = Console.ReadLine();

var reply = await client.SayHelloAsync(new HelloRequest
{
    Name = message
});

Console.WriteLine("Greeting: " + reply.Message);

Console.WriteLine("Shutting down");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();