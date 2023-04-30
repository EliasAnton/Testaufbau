using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

namespace GraphQLClient.Benchmark;

public class GetArticlesBenchmark
{
    private readonly GraphQLHttpClient _graphQlClient;
    public List<GraphQLRequest> RequestList => new List<GraphQLRequest>
        {
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:1){
                    id
                    name
                    articleCategory
                    description
                    price
                    sku
                  }
                }
            "
            },
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:10){
                    id
                    name
                    articleCategory
                    description
                    price
                    sku
                  }
                }
               "
            },
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:100){
                    id
                    name
                    articleCategory
                    description
                    price
                    sku
                  }
                }
               "
            },
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:1000){
                    id
                    name
                    articleCategory
                    description
                    price
                    sku
                  }
                }
               "
            },
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:10000){
                    id
                    name
                    articleCategory
                    description
                    price
                    sku
                  }
                }
               "
            },
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:100000){
                    id
                    name
                    articleCategory
                    description
                    price
                    sku
                  }
                }
               "
            }
        };
    
    public GetArticlesBenchmark()
    {
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new NewtonsoftJsonSerializer());
    }
    
    [ParamsSource(nameof(RequestList))]
    public GraphQLRequest Request { get; set; }

    [Benchmark]
    public async Task GraphQlGetArticles()
    {
        var result = await _graphQlClient.SendQueryAsync<ArticlesQueryResponse>(Request);
    }
}