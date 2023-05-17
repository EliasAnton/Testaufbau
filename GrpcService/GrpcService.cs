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

    /// <summary>
    /// Returns as many articles as specified by the take parameter. If a filter is specified,
    /// only the specified properties are returned. Non nullable properties are always returned.
    /// </summary>
    /// <param name="filter">Comma seperated list of properties</param>
    public GrpcArticlesResponse GetArticles(GrpcTakeRequest request, string? filter = null)
    {
        IQueryable<Article> query = _articleDbContext.Articles!;

        if (!string.IsNullOrEmpty(filter))
        {
            var propertiesToInclude = filter.Split(',');

            query = query.Select(article => new Article
            {
                Name = propertiesToInclude.Contains("Name") ? article.Name : null,
                Description = propertiesToInclude.Contains("Description") ? article.Description : null,
                IsActive = propertiesToInclude.Contains("IsActive") ? article.IsActive : null,
                Color = propertiesToInclude.Contains("Color") ? article.Color : null,
                Width = propertiesToInclude.Contains("Width") ? article.Width : null,
                Height = propertiesToInclude.Contains("Height") ? article.Height : null,
                Depth = propertiesToInclude.Contains("Depth") ? article.Depth : null,
                Weight = propertiesToInclude.Contains("Weight") ? article.Weight : null,
                Material = propertiesToInclude.Contains("Material") ? article.Material : null
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