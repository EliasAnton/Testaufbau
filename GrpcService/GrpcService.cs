using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

namespace GrpcService;

public class GrpcService : IGrpcService
{
    private readonly ArticleDbContext _articleDbContext;

    public GrpcService(ArticleDbContext articleDbContext)
    {
        _articleDbContext = articleDbContext;
    }

    public GrpcArticlesResponse GetArticles(GrpcTakeRequest request, string? filter = null)
    {
        IQueryable<Article> query = _articleDbContext.Articles!;

        if (!string.IsNullOrEmpty(filter))
        {
            // Assuming filter is comma-separated list of property names to include
            var propertiesToInclude = filter.Split(',');

            query = query.Select(article => new Article
            {
                Name = propertiesToInclude.Contains("Name") ? article.Name : null,
                Description = propertiesToInclude.Contains("Description") ? article.Description : null
            });
        }

        query = query.Take(request.Take);

        return new GrpcArticlesResponse { Articles = query.ToList() };
    }

    public GrpcArticlesResponse GetArticlesWithPrice(GrpcTakeRequest request)
    {
        var articles = _articleDbContext.Articles!.Include(a => a.Price).Take(request.Take).ToList();

        return new GrpcArticlesResponse { Articles = articles };
    }

    public Article? GetArticleBySku(GrpcIntRequest skuRequest)
    {
        return _articleDbContext.Articles!
            .FirstOrDefault(a => a.Sku == skuRequest.IntToProcess);
    }

    public Price? GetPriceById(GrpcIntRequest idRequest)
    {
        return _articleDbContext.Prices!
            .FirstOrDefault(a => a.Id == idRequest.IntToProcess);
    }
}