using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class OrderItemType : ObjectGraphType<OrderItem>
{
    public OrderItemType()
    {
        Field(x => x.Id);
        Field(x => x.OrderId);
        Field(x => x.ArticleId);
        Field(x => x.Quantity);
        Field<OrderType>(
            name: "order",
            resolve: context => context.Source.Order
        );
        Field<ArticleType>(
            name: "article",
            resolve: context => context.Source.Article
        );
    }
}