using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;

namespace GraphQLClient.Benchmark;

public class GetOrdersWithOrderItemsBenchmark
{
    private readonly GraphQLHttpClient _graphQlClient;
    public List<GraphQLRequest> RequestList { get; set; }

    public GetOrdersWithOrderItemsBenchmark()
    {
        _graphQlClient = new GraphQLHttpClient("https://localhost:7052/graphql", new SystemTextJsonSerializer());
        RequestList = new();
        FillRequestList();
        Console.WriteLine("blub");
    }

    private void FillRequestList()
    {
        List<int> steps = new()
        {
            1,
            10,
            100,
            1000,
            10000,
            //100000
        };

        foreach (var amount in steps)
        {
            RequestList.Add(new()
            {
                Query = $@"
                query{{
                  getOrders(amount:{amount}){{
                    id
                    orderDate
                    totalPrice
                    customerName
                    customerEmail
                    customerPhone
                    orderItems{{
                      id
                      orderId
                      articleId
                      quantity
                    }}
                  }}
                }}
            "
            });
        }
    }


    [ParamsSource(nameof(RequestList))]
    public GraphQLRequest Request { get; set; }

    [Benchmark]
    public async Task GraphQlGetOrders()
    {
        var result = await _graphQlClient.SendQueryAsync<GetOrdersQueryResponse>(Request);
    }
}