using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQL.Types;
using GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;
using Testaufbau.DataAccess.Models;

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

//var allArticleResponse = await graphQlClient.SendQueryAsync(allArticleRequest, () => new ListGraphType<Article>());
var allArticleResponse = await graphQlClient.SendQueryAsync<AllArticlesQueryResponse>(allArticleRequest);
foreach (var article in allArticleResponse.Data.Articles)
{
    Console.WriteLine(article);
}