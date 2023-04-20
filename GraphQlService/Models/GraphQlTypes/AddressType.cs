using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class AddressType : ObjectGraphType<Address>
{
    public AddressType()
    {
        Field(x => x.Id);
        Field(x => x.Street);
        Field(x => x.HouseNumber);
        Field(x => x.ZipCode);
        Field(x => x.City);
        Field(x => x.Country);
    }
}