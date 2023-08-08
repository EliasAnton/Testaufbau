using BenchmarkDotNet.Running;
using RestClient;
using RestClient.Benchmark;

var summary1 = BenchmarkRunner.Run<GetArticlesBenchmark>();
// var summary2 = BenchmarkRunner.Run<GetOrdersWithArticlesBenchmark>();

// var benchmarkClass = new GetArticlesBenchmark();
// benchmarkClass.NumberOfArticles = 10;
// var result = await benchmarkClass.GetArticles();
// Console.WriteLine(result.Count);
//
// var benchmarkClass2 = new GetOrdersWithArticlesBenchmark();
// benchmarkClass2.NumberOfOrders = 10;
// var result2 = await benchmarkClass2.GetOrdersWithArticlesAndPrices();
// Console.WriteLine(result2.Count);