﻿using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
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
    
    public List<GraphQLRequest> RequestForOnlyIdsList => new List<GraphQLRequest>
        {
            new GraphQLRequest
            {
                Query = @"
                query{
                  getArticles(amount:1){
                    id
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
                  }
                }
               "
            }
        };
    
    public GetArticlesBenchmark()
    {
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());
    }
    
    [ParamsSource(nameof(RequestForOnlyIdsList))]
    public GraphQLRequest Request { get; set; }

    [Benchmark]
    public async Task GraphQlGetArticles()
    {
        var result = await _graphQlClient.SendQueryAsync<AllArticlesQueryResponse>(Request);
    }
}