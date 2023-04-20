using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class ArticleType : ObjectGraphType<Article>
{
    public ArticleType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.ArticleCategory);
        Field(x => x.Description, nullable:true);
        Field(x => x.Price);
        Field(x => x.SKU);
    }
}