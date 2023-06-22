using GraphQL.DataLoader;
using GraphQL.Types;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public sealed class ArticleType : ObjectGraphType<Article>
{
    public ArticleType(ArticleDbContext articleDbContext, IDataLoaderContextAccessor dataLoader)
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Description, true);
        Field(x => x.Sku);
        Field(x => x.PriceId);
        // Field<PriceType>(
        //     "Price",
        //     resolve: context => articleDbContext.Prices!.FirstOrDefault(x => x.Id == context.Source.PriceId)
        // );
        //Dies soll die Datenbankabfrage optimieren, indem die Preise aller Artikel in einem Batch geladen werden wenn viele Artikel angefragt werden
        Field<PriceType>(
            "Price",
            resolve: context =>
            {
                var loader = dataLoader.Context!.GetOrAddBatchLoader<int, Price>(
                    "GetPriceById",
                    articleDbContext.GetPricesByIdAsync);
                return loader.LoadAsync(context.Source.PriceId);
            });
        Field(x => x.IsActive, true);
        Field(x => x.Color, true);
        Field(x => x.Width, true);
        Field(x => x.Height, true);
        Field(x => x.Depth, true);
        Field(x => x.Weight, true);
        Field(x => x.Material, true);
    }
}