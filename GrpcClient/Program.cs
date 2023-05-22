using BenchmarkDotNet.Running;
using Grpc.Net.Client;
using GrpcClient.Benchmark;
using ProtoBuf.Grpc.Client;
using Testaufbau.DataAccess.Grpc;

// using var channel = GrpcChannel.ForAddress("https://localhost:7214", new GrpcChannelOptions
// {
//     MaxReceiveMessageSize = null
// });

// var grpcService = channel.CreateGrpcService<IGrpcService>();
// var result = await grpcService.GetArticlesAsync(new GrpcTakeRequest() { Take = 10 });
// var article = result.Articles.First();
// Console.WriteLine("Erster Artikel Id und Sku und Name:");
// Console.WriteLine(article.Id);
// Console.WriteLine(article.Sku);
// Console.WriteLine(article.Name);
//
// var article1 = await grpcService.GetArticleByIdAsync(new GrpcIntRequest() { IntToProcess = article.Id });
// var article2 = await grpcService.GetArticleBySku(new GrpcIntRequest() { IntToProcess = article.Sku });
//
// Console.WriteLine("Vergleich der Artikel Id und Sku und Name:");
// Console.WriteLine(article1.Id == article2.Id);
// Console.WriteLine(article1.Sku == article2.Sku);
// Console.WriteLine(article1.Name == article2.Name);
//
// var price = await grpcService.GetPriceByIdAsync(new GrpcIntRequest() { IntToProcess = article1.PriceId });
// Console.WriteLine("Preis Id und Amount und Currency und Country:");
// Console.WriteLine(price.Id);
// Console.WriteLine(price.Amount);
// Console.WriteLine(price.Currency);
// Console.WriteLine(price.Country);

//Run benchmark
var summary1 = BenchmarkRunner.Run<GetArticlesBenchmark>();
var summary2 = BenchmarkRunner.Run<GetOrdersWithArticlesBenchmark>();


// var benchmark = new GetArticlesBenchmark();
// benchmark.NumberOfArticles = 10;
// var result = benchmark.GetArticles();
// Console.WriteLine(result.Count);
//
// var benchmark2 = new GetOrdersWithArticlesBenchmark();
// benchmark2.NumberOfOrders = 10;
// var result2 = await benchmark2.GetOrdersWithArticlesAndPrices();
// Console.WriteLine(result2.Count);