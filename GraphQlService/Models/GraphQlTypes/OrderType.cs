using GraphQL.Types;
using Testaufbau.DataAccess.Models;

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
        Field(x => x.CustomerEmail, nullable: true);
        Field(x => x.CustomerPhone, nullable: true);
        Field<ListGraphType<OrderItemType>>(
            name: "orderItems",
            resolve: context => context.Source.OrderItems
        );
        Field<AddressType>(
            name: "customerAddress",
            resolve: context => context.Source.CustomerAddress
        );
    }
}