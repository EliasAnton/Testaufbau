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
            name: "order",
            resolve: context => Queryable.FirstOrDefault(dbContext.Orders!, x => x.Id == context.Source.OrderId)
        );
        Field<ArticleType>(
            name: "article",
            resolve: context => Queryable.FirstOrDefault(dbContext.Articles!, x => x.Id == context.Source.ArticleId)
        );
    }
}