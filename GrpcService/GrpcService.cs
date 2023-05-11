using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

namespace GrpcService;

public class GrpcService : IGrpcService
{
    private readonly ArticleDbContext _dbContext;

    public GrpcService(ArticleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<GrpcArticlesResponse> GetArticlesAsync(GrpcTakeRequest request)
    {
        var articles = _dbContext.Articles!
            .Take(request.Take).ToList();
        var response = new GrpcArticlesResponse { Articles = articles };
        return Task.FromResult(response);
    }

    public Task<Article?> GetArticleAsync(GrpcIdRequest idRequest)
    {
        var article = _dbContext.Articles!
            .FirstOrDefault(a => a.Id == idRequest.Id);
        return Task.FromResult(article);
    }

    public Task<GrpcArticlesResponse> GetAllArticlesAsync()
    {
        var articles = _dbContext.Articles!
            .ToList();
        var response = new GrpcArticlesResponse { Articles = articles };
        return Task.FromResult(response);
    }
}