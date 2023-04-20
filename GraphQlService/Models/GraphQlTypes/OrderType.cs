using GraphQL.Types;
using Testaufbau.DataAccess.SharedModels;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class OrderType : ObjectGraphType<Order>
{
    public OrderType()
    {
        Field(x => x.Id);
        Field(x => x.OrderDate);
        Field(x => x.TotalPrice);
        Field(x => x.CustomerName);
        Field(x => x.CustomerAddressId);
        Field(x => x.CustomerEmail);
        Field(x => x.CustomerPhone);

        Field<ListGraphType<OrderItemType>>(
            name: "orderItems",
            resolve: context => context.Source.OrderItems
        );
    }
}