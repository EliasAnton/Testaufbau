using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public sealed class OrderItemType : ObjectGraphType<OrderItem>
{
    public OrderItemType(OrderDbContext orderDbContext)
    {
        Field(x => x.Id);
        Field(x => x.OrderId);
        Field(x => x.ArticleSku);
        Field(x => x.Quantity);
        Field<OrderType>(
            "order",
            resolve: context => orderDbContext.Orders!.FirstOrDefault(x => x.Id == context.Source.OrderId)
        );
    }
}