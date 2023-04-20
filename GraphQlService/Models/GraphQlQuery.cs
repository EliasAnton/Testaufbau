using GraphQL.Types;
using GraphQlService.Models.GraphQlTypes;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;

namespace GraphQlService.Models;

public class GraphQlQuery : ObjectGraphType, IGraphQlQuery
{
    private readonly MariaDbContext _dbContext;

    public GraphQlQuery(MariaDbContext dbContext)
    {
        _dbContext = dbContext;

        Name = "Query";
        
        FieldAsync<ListGraphType<ArticleType>>(
            "allArticles",
            resolve: async context => await _dbContext.Articles!.ToListAsync()
        );
        FieldAsync<ListGraphType<OrderType>>(
            "allOrders",
            resolve: async context => await _dbContext.Orders!.ToListAsync()
        );
        FieldAsync<ListGraphType<OrderItemType>>(
            "allOrderItems",
            resolve: async context => await _dbContext.OrderItems!.ToListAsync()
        );
        FieldAsync<ListGraphType<AddressType>>(
            "allAddresses",
            resolve: async context => await _dbContext.Addresses!.ToListAsync()
        );
    }

}