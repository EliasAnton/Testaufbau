using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public sealed class ArticleType : ObjectGraphType<Article>
{
    public ArticleType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Description, true);
        Field(x => x.Price);
        Field(x => x.Sku);
    }
}