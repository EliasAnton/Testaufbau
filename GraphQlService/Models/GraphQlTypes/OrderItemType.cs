using GraphQL.Types;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class OrderItemType : ObjectGraphType<OrderItem>
{
    public OrderItemType(MariaDbContext dbContext)
    {
        Field(x => x.Id);
        Field(x => x.OrderId);
        Field(x => x.ArticleId);
        Field(x => x.Quantity);
        Field<OrderType>(
            name: "order",
            resolve: context => dbContext.Orders!
                .FirstOrDefault(x => x.Id == context.Source.OrderId)
        );
        Field<ArticleType>(
            name: "article",
            resolve: context => dbContext.Articles!
                .FirstOrDefault(x => x.Id == context.Source.ArticleId)
        );
    }
}