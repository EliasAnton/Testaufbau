using BenchmarkDotNet.Running;
using RestClient;
using RestClient.Benchmark;

// var client = new LocalClient();
// await LocalClient.RunUserPrompts();

//var summary = BenchmarkRunner.Run<GetArticlesBenchmark>();
var summary = BenchmarkRunner.Run<GetOrdersWithOrderItemsBenchmark>();