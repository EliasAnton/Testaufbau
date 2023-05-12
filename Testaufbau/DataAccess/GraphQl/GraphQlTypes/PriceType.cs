using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public class PriceType : ObjectGraphType<Price>
{
    public PriceType()
    {
        Field(x => x.Id);
        Field(x => x.Amount);
        Field(x => x.Currency);
        Field(x => x.Country);
    }
}