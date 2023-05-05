using RestClient;

var client = new LocalClient();
await LocalClient.RunUserPrompts();

//var summary = BenchmarkRunner.Run<GetArticlesBenchmark>();