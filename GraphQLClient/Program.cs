using BenchmarkDotNet.Running;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQLClient.Benchmark;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;

// var graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());
//
// var allArticleRequest = new GraphQLRequest
// {
//     Query = @"
//          query{
//           getArticles(amount:20){
//             id
//             name
//             articleCategory
//             description
//             price
//             sku
//           }
//         }
//      "
// };
// var allArticleResponse = await graphQlClient.SendQueryAsync<GetArticlesQueryResponse>(allArticleRequest);
// foreach (var article in allArticleResponse.Data.Articles)
// {
//     Console.WriteLine(article.IntToProcess);
//     Console.WriteLine(article.Name);
//     Console.WriteLine("-----------------");
// }

// var benchmarkClass = new GetArticlesBenchmark();
// benchmarkClass.NumberOfArticles = 10;
// var result = await benchmarkClass.GetArticles();
// Console.WriteLine(result.Count);

// var benchmarkClass2 = new GetOrdersWithArticlesBenchmark();
// benchmarkClass2.NumberOfOrders = 10;
// var result2 = await benchmarkClass2.GetOrdersWithArticlesAndPrices();
// Console.WriteLine(result2.Count);


BenchmarkRunner.Run<GetArticlesBenchmark>();
// BenchmarkRunner.Run<GetOrdersWithArticlesBenchmark>();