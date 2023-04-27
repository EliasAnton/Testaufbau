using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

namespace GraphQLClient.Benchmark;

public class RoundtripBenchmark
{
    private readonly GraphQLHttpClient _graphQlClient;
    private readonly GraphQLRequest _allArticleRequest;
    public RoundtripBenchmark()
    {
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new NewtonsoftJsonSerializer());
        _allArticleRequest = new GraphQLRequest
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
    }

    [Benchmark]
    public async Task GraphQlAllArticlesRoundtrip()
    {
        var result = await _graphQlClient.SendQueryAsync<AllArticlesQueryResponse>(_allArticleRequest);
    }
}