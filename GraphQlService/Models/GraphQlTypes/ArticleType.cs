using GraphQL.Types;
using Testaufbau.DataAccess.SharedModels;

namespace GraphQlService.Models.GraphQlTypes;

public sealed class ArticleType : ObjectGraphType<Article>
{
    public ArticleType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.ArticleCategory);
        Field(x => x.Description);
        Field(x => x.Price);
        Field(x => x.SKU);
    }
}