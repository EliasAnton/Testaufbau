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

    public GrpcArticlesResponse GetArticles(GrpcTakeRequest request)
    {
        var articles = _articleDbContext.Articles!
            .Take(request.Take).ToList();
        return new GrpcArticlesResponse { Articles = articles };
    }

    public Article? GetArticleById(GrpcIntRequest idRequest)
    {
        return _articleDbContext.Articles!
            .FirstOrDefault(a => a.Id == idRequest.IntToProcess);
    }

    //Get article by sku
    public Article? GetArticleBySku(GrpcIntRequest skuRequest)
    {
        return _articleDbContext.Articles!
            .FirstOrDefault(a => a.Sku == skuRequest.IntToProcess);
    }

    public GrpcArticlesResponse GetAllArticles()
    {
        var articles = _articleDbContext.Articles!
            .ToList();
        return new GrpcArticlesResponse { Articles = articles };
    }

    //get price by id
    public Price? GetPriceById(GrpcIntRequest idRequest)
    {
        return _articleDbContext.Prices!
            .FirstOrDefault(a => a.Id == idRequest.IntToProcess);
    }
}