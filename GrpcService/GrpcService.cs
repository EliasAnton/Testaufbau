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
        var response = new GrpcArticlesResponse() { Articles = articles };
        return Task.FromResult(response);
    }

    public Task<GrpcOrdersResponse> GetOrdersAsync(GrpcTakeRequest request)
    {
        var orders = _dbContext.Orders!
            .Take(request.Take)
            .ToList();
        var response = new GrpcOrdersResponse() { Orders = orders };
        return Task.FromResult(response);
    }

    public Task<GrpcOrdersResponse> GetOrderAsync(GrpcIdRequest idRequest)
    {
        var order = _dbContext.Orders!
            .FirstOrDefault(o => o.Id == idRequest.Id);
        var response = new GrpcOrdersResponse() { Orders = new List<Order> { order } };
        return Task.FromResult(response);
    }

    public Task<GrpcOrdersResponse> GetAllOrdersAsync()
    {
        var orders = _dbContext.Orders!
            .ToList();
        var response = new GrpcOrdersResponse() { Orders = orders };
        return Task.FromResult(response);
    }

    public Task<GrpcOrderItemsResponse> GetOrderItemsAsync(GrpcIdRequest idRequest)
    {
        var orderItems = _dbContext.OrderItems!
            .Where(oi => oi.OrderId == idRequest.Id)
            .ToList();
        var response = new GrpcOrderItemsResponse() { OrderItems = orderItems };
        return Task.FromResult(response);
    }

    public Task<Address?> GetAddressByIdAsync(GrpcIdRequest idRequest)
    {
        var address = _dbContext.Addresses!
            .FirstOrDefault(a => a.Id == idRequest.Id);
        return Task.FromResult(address);
    }

}