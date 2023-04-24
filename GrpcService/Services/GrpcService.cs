using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.Grpc;
using Testaufbau.DataAccess.Models;

namespace GrpcService.Services;

public class GrpcService : IGrpcService
{
    private readonly MariaDbContext _dbContext;
    public GrpcService(MariaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Article>> GetAllArticlesAsync()
    {
        var articles = _dbContext.Articles!
            .ToList();
        return Task.FromResult(articles);
    }

    public Task<Article?> GetArticleByIdAsync(int id)
    {
        var article = _dbContext.Articles!
            .FirstOrDefault(a => a.Id == id);
        return Task.FromResult(article);
    }

    public Task<GrpcResponse> GetAllOrdersAsync()
    {
        var orders = _dbContext.Orders!
            .Include(o => o.OrderItems!)
            .ThenInclude(oi => oi.Article)
            .ToList();
        var response = new GrpcResponse() { Orders = orders };
        return Task.FromResult(response);
    }

    public Task<Address> GetAddressByIdAsync(GrpcRequest request)
    {
        var address = _dbContext.Addresses!
            .FirstOrDefault(a => a.Id == request.Id);
        return Task.FromResult(address!);
    }
}