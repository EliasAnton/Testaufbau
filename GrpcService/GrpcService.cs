using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

namespace GrpcService;

public class GrpcService : IGrpcService
{
    private readonly MariaDbContext _dbContext;
    public GrpcService(MariaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<GrpcArticlesResponse> GetArticlesAsync(GrpcArticlesRequest request)
    {
        var articles = _dbContext.Articles!
            .Take(request.Take).ToList();
        var response = new GrpcArticlesResponse { Articles = articles };
        return Task.FromResult(response);
    }
    
    public Task<GrpcArticlesResponse> GetAllArticlesAsync()
    {
        var articles = _dbContext.Articles!
            .ToList();
        var response = new GrpcArticlesResponse() { Articles = articles };
        return Task.FromResult(response);
    }

    public Task<Article?> GetArticleByIdAsync(GrpcIdRequest idRequest)
    {
        var article = _dbContext.Articles!
            .FirstOrDefault(a => a.Id == idRequest.Id);
        return Task.FromResult(article);
    }

    public Task<GrpcOrderResponse> GetAllOrdersAsync()
    {
        var orders = _dbContext.Orders!
            .Include(o => o.CustomerAddress!)
            .Include(o => o.OrderItems!)
            .ThenInclude(oi => oi.Article)
            .ToList();
        var response = new GrpcOrderResponse() { Orders = orders };
        return Task.FromResult(response);
    }

    public Task<Address?> GetAddressByIdAsync(GrpcIdRequest idRequest)
    {
        var address = _dbContext.Addresses!
            .FirstOrDefault(a => a.Id == idRequest.Id);
        return Task.FromResult(address);
    }
}