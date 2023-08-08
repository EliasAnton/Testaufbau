using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;
using Testaufbau.DataAccess.Models;

namespace GraphQLClient.Benchmark;

public class GetArticlesBenchmark
{
    private readonly GraphQLHttpClient _graphQlClient;

    public GetArticlesBenchmark()
    {
        //5001 wenn service unter publish läuft, 7052 wenn über IDE
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());
    }

    public List<int> AmountList => new()
    {
        1,
        10,
        100,
        1000,
        10000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfArticles { get; set; }

    //[Benchmark]
    public async Task<List<Article>> GetArticles()
    {
        var articleResponse = await _graphQlClient.SendQueryAsync<GetArticlesQueryResponse>(CreateGetArticlesRequest(NumberOfArticles));
        return articleResponse.Data.Articles;
    }
    
    //[Benchmark]
    public async Task<List<Article>> GetReducedArticles()
    {
        var articleResponse = await _graphQlClient.SendQueryAsync<GetArticlesQueryResponse>(CreateReducedGetArticlesRequest(NumberOfArticles));
        return articleResponse.Data.Articles;
    }

    [Benchmark]
    public async Task<List<Article>> GetArticlesWithPrice()
    {
        var articleResponse = await _graphQlClient.SendQueryAsync<GetArticlesQueryResponse>(CreateGetArticlesWithPriceRequest(NumberOfArticles));
        return articleResponse.Data.Articles;
    }

    private GraphQLRequest CreateGetArticlesRequest(int amount)
    {
        return new()
        {
            Query = $@"
                query{{
                  getArticles(amount:{amount}){{
                    id
                    name
                    sku
                    description
                    priceId
                    isActive
                    color
                    width
                    height
                    depth
                    weight
                    material
                  }}
                }}
            "
        };
    }

    private GraphQLRequest CreateReducedGetArticlesRequest(int amount)
    {
        return new()
        {
            Query = $@"
                query{{
                  getArticles(amount:{amount}){{
                    id
                    name
                    sku
                    description
                    priceId
                  }}
                }}
            "
        };
    }

    private GraphQLRequest CreateGetArticlesWithPriceRequest(int amount)
    {
        return new()
        {
            Query = $@"
                query{{
                  getArticles(amount:{amount}){{
                    id
                    name
                    sku
                    description
                    priceId
                    price{{
                      id
                      amount
                      currency
                      country
                    }}
                    isActive
                    color
                    width
                    height
                    depth
                    weight
                    material
                  }}
                }}
            "
        };
    }
}