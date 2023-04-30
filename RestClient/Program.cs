using BenchmarkDotNet.Running;
using RestClient.Benchmark;

// var client = new LocalClient();
// await LocalClient.RunUserPrompts();

var summary = BenchmarkRunner.Run<GetArticlesBenchmark>();