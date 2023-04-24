using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;
using Testaufbau.DataAccess.Models;

var graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());

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

var allArticleResponse = await graphQlClient.SendQueryAsync(allArticleRequest, () => new List<Article>());
Console.WriteLine("Blub");
{
    //Console.WriteLine(article);
}