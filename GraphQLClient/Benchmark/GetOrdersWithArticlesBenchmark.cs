using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;
using Testaufbau.DataAccess.Models;

namespace GraphQLClient.Benchmark;

public class GetOrdersWithArticlesBenchmark
{
    private readonly GraphQLHttpClient _graphQlClient;
    
    private readonly OrderDbContext _orderDbContext;

    private static readonly string ConnectionString = "Server=localhost;Port=3307;Database=OrderDb;Uid=root;Pwd=SuperSecretRootPassword1234;";


    public GetOrdersWithArticlesBenchmark()
    {
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());
        
        var options = new DbContextOptionsBuilder<OrderDbContext>()
            .UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
            .Options;
        _orderDbContext = new OrderDbContext(options);
    }

    
    
    public static List<int> AmountList => new()
    {
        1,
        10,
        100,
        1000,
        10000,
        //100000
    };

    [ParamsSource(nameof(AmountList))]
    public int NumberOfOrders { get; set; }

    [Benchmark]
    public async Task<List<Order>> GetOrdersWithArticlesAndPrices()
    {
        var orders = await _orderDbContext.Orders!
            .Include(o => o.OrderItems)
            .Take(NumberOfOrders)
            .ToListAsync();

        foreach (var order in orders)
        {
            foreach (var orderItem in order.OrderItems!)
            {
                var articleResponse = await _graphQlClient.SendQueryAsync<GetArticleBySkuQueryResponse>(CreateGetArticleBySkuRequest(orderItem.ArticleSku));
                orderItem.Article = articleResponse.Data.Article;
            }
        }

        return orders;
    }

    private GraphQLRequest CreateGetArticleBySkuRequest(int articleSku)
    {
        return new()
        {
            Query = $@"
                query{{
                  getArticleBySku(sku:{articleSku}){{
                    id
                    name
                    description
                    sku
                    priceId
                    price{{
                      id
                      amount
                      currency
                      country
                    }}
                  }}
                }}
            "
        };
    }
}