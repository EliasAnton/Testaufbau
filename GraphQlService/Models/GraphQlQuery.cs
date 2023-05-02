﻿using GraphQL;
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
            "getArticles",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "amount" }
            ),
            resolve: async context =>
            {
                var amount = context.GetArgument<int>("amount");
                return await _dbContext.Articles!.Take(amount).ToListAsync();
            }
        );
        FieldAsync<ArticleType>(
            "getArticleById",
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
                return await _dbContext.Orders!
                    .Take(amount)
                    .ToListAsync();
            }
        );
        FieldAsync<OrderType>(
            "getOrderById",
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
            "allOrderItems",
            resolve: async context => await _dbContext.OrderItems!.ToListAsync()
        );


        FieldAsync<AddressType>(
            "getAddressById",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: async context =>
            {
                var id = context.GetArgument<int>("id");
                return await _dbContext.Addresses!
                    .FirstOrDefaultAsync(a => a.Id == id);
            }
        );
    }

}