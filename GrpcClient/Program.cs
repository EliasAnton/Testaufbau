using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Testaufbau.DataAccess.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:7214");
var greeterService = channel.CreateGrpcService<IGreeterService>();
var grpcService = channel.CreateGrpcService<IGrpcService>();

// Console.WriteLine("Wie heist du?");
// var message = Console.ReadLine();
//
// var reply = await greeterService.SayHelloAsync(new HelloRequest
// {
//     Name = message!
// });
//
// Console.WriteLine("Greeting: " + reply.Message);

var article = await grpcService.GetAddressByIdAsync(new GrpcRequest() { Id = 1 });
Console.WriteLine("Land von Adresse 1: " + article!.Country);

var response = await grpcService.GetAllOrdersAsync();
foreach (var order in response.Orders)
{
    Console.WriteLine("Id: " + order.Id);
    Console.WriteLine("Datum: " + order.OrderDate);
    Console.WriteLine("Anzahl Positionen: " + order.OrderItems!.Count);
    Console.WriteLine(order.OrderItems.First().Quantity + " mal Artikel: " + order.OrderItems.First().Article!.Name);
    Console.WriteLine("--------------------------------");
}


Console.WriteLine("Shutting down");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();