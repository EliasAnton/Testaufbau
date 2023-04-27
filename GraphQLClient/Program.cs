using BenchmarkDotNet.Running;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQLClient.Benchmark;
using GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

//TODO get it to work with System.Text.Json
var graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new NewtonsoftJsonSerializer());

var allArticleRequest = new GraphQLRequest
{
    Query = @"
        query{
          allArticles{
            id
            name
            articleCategory
            description
            price
            sku
          }
        }
    "
};

var allArticleResponse = await graphQlClient.SendQueryAsync<AllArticlesQueryResponse>(allArticleRequest);
foreach (var article in allArticleResponse.Data.Articles)
{
    Console.WriteLine(article.Id);
    Console.WriteLine(article.Name);
    Console.WriteLine("-----------------");
}

BenchmarkRunner.Run<RoundtripBenchmark>();