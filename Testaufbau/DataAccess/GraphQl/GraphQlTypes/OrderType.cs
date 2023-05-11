using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public sealed class OrderType : ObjectGraphType<Order>
{
    public OrderType(OrderDbContext dbContext)
    {
        Field(x => x.Id);
        Field(x => x.OrderDate);
        Field(x => x.TotalPrice);
        Field(x => x.CustomerName);
        Field(x => x.CustomerEmail, nullable: true);
        Field(x => x.CustomerPhone, nullable: true);
        Field<ListGraphType<OrderItemType>>(
            "orderItems",
            resolve: context => dbContext.OrderItems!.Where(x => x.OrderId == context.Source.Id)
                .ToList()
        );
    }
}