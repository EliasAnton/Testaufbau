using GraphQL.Types;
using Testaufbau.DataAccess.SharedModels;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class OrderItemType : ObjectGraphType<OrderItem>
{
    public OrderItemType()
    {
        Field(x => x.Id);
        Field(x => x.OrderId);
        Field(x => x.ArticleId);
        Field(x => x.Quantity);
    }
}