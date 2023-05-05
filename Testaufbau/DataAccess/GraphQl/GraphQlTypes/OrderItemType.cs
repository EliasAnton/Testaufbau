using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public sealed class OrderItemType : ObjectGraphType<OrderItem>
{
    public OrderItemType(MariaDbContext dbContext)
    {
        Field(x => x.Id);
        Field(x => x.OrderId);
        Field(x => x.ArticleId);
        Field(x => x.Quantity);
        Field<OrderType>(
            "order",
            resolve: context => dbContext.Orders!.FirstOrDefault(x => x.Id == context.Source.OrderId)
        );
        Field<ArticleType>(
            "article",
            resolve: context => dbContext.Articles!.FirstOrDefault(x => x.Id == context.Source.ArticleId)
        );
    }
}