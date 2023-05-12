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

    public Task<GrpcArticlesResponse> GetArticlesAsync(GrpcTakeRequest request)
    {
        var articles = _articleDbContext.Articles!
            .Take(request.Take).ToList();
        var response = new GrpcArticlesResponse { Articles = articles };
        return Task.FromResult(response);
    }

    public Task<Article?> GetArticleByIdAsync(GrpcIntRequest idRequest)
    {
        var article = _articleDbContext.Articles!
            .FirstOrDefault(a => a.Id == idRequest.IntToProcess);
        return Task.FromResult(article);
    }
    
    //Get article by sku
    public Task<Article?> GetArticleBySkuAsync(GrpcIntRequest skuRequest)
    {
        var article = _articleDbContext.Articles!
            .FirstOrDefault(a => a.Sku == skuRequest.IntToProcess);
        return Task.FromResult(article);
    }

    public Task<GrpcArticlesResponse> GetAllArticlesAsync()
    {
        var articles = _articleDbContext.Articles!
            .ToList();
        var response = new GrpcArticlesResponse { Articles = articles };
        return Task.FromResult(response);
    }
    
    //get price by id
    public Task<Price?> GetPriceByIdAsync(GrpcIntRequest idRequest)
    {
        var price = _articleDbContext.Prices!
            .FirstOrDefault(a => a.Id == idRequest.IntToProcess);
        return Task.FromResult(price);
    }
}

