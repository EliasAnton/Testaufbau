using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;

namespace GraphQLClient.Benchmark;

public class RoundtripBenchmark
{
    private readonly GraphQLRequest _allArticleRequest;
    private readonly GraphQLHttpClient _graphQlClient;

    public RoundtripBenchmark()
    {
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());
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

    [Benchmark]
    public async Task GraphQlGetArticles()
    {
        var result = await _graphQlClient.SendQueryAsync<AllArticlesQueryResponse>(_allArticleRequest);
    }
}