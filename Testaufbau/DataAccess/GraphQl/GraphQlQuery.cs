using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.GraphQl.GraphQlTypes;

namespace Testaufbau.DataAccess.GraphQl;

public class GraphQlQuery : ObjectGraphType, IGraphQlQuery
{
    private readonly ArticleDbContext _articleDbContext;

    public GraphQlQuery(ArticleDbContext articleDbContext)
    {
        _articleDbContext = articleDbContext;

        Name = "Query";

        FieldAsync<ListGraphType<ArticleType>>(
            "getArticles",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "amount" }
            ),
            resolve: async context =>
            {
                var amount = context.GetArgument<int>("amount");
                return await _articleDbContext.Articles!.Take(amount).ToListAsync();
            }
        );
        FieldAsync<ArticleType>(
            "getArticle",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: async context =>
            {
                var id = context.GetArgument<int>("id");
                return await _articleDbContext.Articles!.FirstOrDefaultAsync(a => a.Id == id);
            }
        );
        FieldAsync<ListGraphType<ArticleType>>(
            "allArticles",
            resolve: async context => await _articleDbContext.Articles!.ToListAsync()
        );
    }
}