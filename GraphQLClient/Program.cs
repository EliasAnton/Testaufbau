using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

//TODO get it to work with System.Text.Json
 var graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());

 var allArticleRequest = new GraphQLRequest
 {
     Query = @"
         query{
          getArticles(amount:20){
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

 var allArticleResponse = await graphQlClient.SendQueryAsync<GetArticlesQueryResponse>(allArticleRequest);
 foreach (var article in allArticleResponse.Data.Articles)
 {
     Console.WriteLine(article.Id);
     Console.WriteLine(article.Name);
     Console.WriteLine("-----------------");
 }

//BenchmarkRunner.Run<RoundtripBenchmark>();
//BenchmarkRunner.Run<GetArticlesBenchmark>();