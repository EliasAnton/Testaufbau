using BenchmarkDotNet.Running;
using Grpc.Net.Client;
using Grpc.Net.ClientFactory;
using GrpcClient.Benchmark;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Grpc;
using IGrpcService = Testaufbau.DataAccess.Grpc.IGrpcService;

// using var channel = GrpcChannel.ForAddress("https://localhost:7214", new GrpcChannelOptions
// {
//     MaxReceiveMessageSize = null
// });
//
// var grpcService = channel.CreateGrpcService<IGrpcService>();
// var result = await grpcService.GetArticlesAsync(new GrpcArticlesRequest() { Take = 100000 });
//
//
// Console.WriteLine("Moin");
//
// var address = await grpcService.GetAddressByIdAsync(new GrpcIdRequest() { Id = 1 });
// Console.WriteLine("Land von Adresse 1: " + address!.Country);
//
// var response = await grpcService.GetAllOrdersAsync();
// foreach (var order in response.Orders)
// {
//     Console.WriteLine("Id: " + order.Id);
//     Console.WriteLine("Datum: " + order.OrderDate);
//     Console.WriteLine("Anzahl Positionen: " + order.OrderItems!.Count);
//     Console.WriteLine(order.OrderItems.First().Quantity + " mal Artikel: " + order.OrderItems.First().Article!.Name);
//     Console.WriteLine("--------------------------------");
// }
//
// var article = await grpcService.GetArticleByIdAsync(new GrpcIdRequest() { Id = 1 });
// Console.WriteLine("Artikel 1: " + article!.Name);
//
// var articles = await grpcService.GetAllArticlesAsync();
// foreach (var art in articles.Articles)
// {
//     Console.WriteLine("Artikel " + art.Id + ": " + art.Name);
// }
//
// Console.WriteLine("Shutting down");
// Console.WriteLine("Press any key to exit...");
// Console.ReadKey();

//Run benchmark
var summary = BenchmarkRunner.Run<GetArticlesBenchmark>();
