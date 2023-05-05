using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;

namespace Testaufbau.DataAccess.GraphQl;

public class GraphQlQuery : ObjectGraphType, IGraphQlQuery
{
    private readonly MariaDbContext _dbContext;

    public GraphQlQuery(MariaDbContext dbContext)
    {
        _dbContext = dbContext;

        Name = "Query";

        FieldAsync<ListGraphType<ArticleType>>(
            "getArticles",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "amount" }
            ),
            resolve: async context =>
            {
                var amount = context.GetArgument<int>("amount");
                return await Queryable.Take(_dbContext.Articles!, (int)amount).ToListAsync();
            }
        );
        FieldAsync<ArticleType>(
            "getArticle",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: async context =>
            {
                var id = context.GetArgument<int>("id");
                return await _dbContext.Articles!.FirstOrDefaultAsync(a => a.Id == id);
            }
        );
        FieldAsync<ListGraphType<ArticleType>>(
            "allArticles",
            resolve: async context => await _dbContext.Articles!.ToListAsync()
        );

        FieldAsync<ListGraphType<OrderType>>(
            "getOrders",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "amount" }
            ),
            resolve: async context =>
            {
                var amount = context.GetArgument<int>("amount");
                return await Queryable.Take(_dbContext.Orders!, (int)amount)
                    .ToListAsync();
            }
        );
        FieldAsync<OrderType>(
            "getOrder",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: async context =>
            {
                var id = context.GetArgument<int>("id");
                return await _dbContext.Orders!
                    .FirstOrDefaultAsync(o => o.Id == id);
            }
        );
        FieldAsync<ListGraphType<OrderType>>(
            "allOrders",
            resolve: async context => await _dbContext.Orders!.ToListAsync()
        );

        FieldAsync<ListGraphType<OrderItemType>>(
            "getOrderItems",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "orderId" }
            ),
            resolve: async context =>
            {
                var id = context.GetArgument<int>("id");
                return await _dbContext.OrderItems!
                    .Where(oi => oi.OrderId == id)
                    .ToListAsync();
            });
    }

}