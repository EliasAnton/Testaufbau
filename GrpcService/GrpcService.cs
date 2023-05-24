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
    public Task<GrpcArticlesResponse> GetArticles(GrpcTakeRequestWithFilter request)
    {
        IQueryable<Article> query = _articleDbContext.Articles!;

        if (!string.IsNullOrEmpty(request.Filter))
        {
            var propertiesToInclude = request.Filter.Split(',');

            query = query.Select(article => new Article
            {
                Id = article.Id,
                Name = propertiesToInclude.Contains("Name") ? article.Name : null,
                Sku = article.Sku,
                Description = propertiesToInclude.Contains("Description") ? article.Description : null,
                PriceId = article.PriceId,
                IsActive = propertiesToInclude.Contains("IsActive") ? article.IsActive : null,
                Color = propertiesToInclude.Contains("Color") ? article.Color : null,
                Width = propertiesToInclude.Contains("Width") ? article.Width : null,
                Height = propertiesToInclude.Contains("Height") ? article.Height : null,
                Depth = propertiesToInclude.Contains("Depth") ? article.Depth : null,
                Weight = propertiesToInclude.Contains("Weight") ? article.Weight : null,
                Material = propertiesToInclude.Contains("Material") ? article.Material : null
            });
        }

        var articles = query.Take(request.Take).ToList();

        return Task.FromResult(new GrpcArticlesResponse { Articles = articles });
    }

    public Task<GrpcArticlesResponse> GetArticlesWithPrice(GrpcTakeRequest request)
    {
        var articles = _articleDbContext.Articles!
            .Include(a => a.Price)
            .Take(request.Take).ToList();
        return Task.FromResult(new GrpcArticlesResponse { Articles = articles });
    }

    public Task<Article?> GetArticleWithPriceBySku(GrpcIntRequest skuRequest)
    {
        return Task.FromResult(_articleDbContext.Articles!
            .Include(a => a.Price)
            .FirstOrDefault(a => a.Sku == skuRequest.IntToProcess));
    }

    public Task<Article?> GetArticleBySku(GrpcIntRequest skuRequest)
    {
        return Task.FromResult(_articleDbContext.Articles!
            .FirstOrDefault(a => a.Sku == skuRequest.IntToProcess));
    }

    public Task<Price?> GetPriceById(GrpcIntRequest idRequest)
    {
        return Task.FromResult(_articleDbContext.Prices!
            .FirstOrDefault(a => a.Id == idRequest.IntToProcess));
    }
}