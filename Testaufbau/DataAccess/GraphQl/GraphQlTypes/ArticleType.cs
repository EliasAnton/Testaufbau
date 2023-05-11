using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public sealed class ArticleType : ObjectGraphType<Article>
{
    public ArticleType(ArticleDbContext articleDbContext)
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Description, true);
        Field(x => x.Sku);
        Field(x => x.PriceId);
        Field<PriceType>(
            "Price",
            resolve: context => articleDbContext.Prices!.FirstOrDefault(x => x.Id == context.Source.PriceId)
        );
    }
}