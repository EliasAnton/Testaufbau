using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    Task<GrpcArticlesResponse> GetArticlesAsync(GrpcTakeRequest request);
    Task<Article?> GetArticleByIdAsync(GrpcIntRequest intRequest);
    Task<GrpcArticlesResponse> GetAllArticlesAsync();
    Task<Article?> GetArticleBySkuAsync(GrpcIntRequest skuRequest);
    Task<Price?> GetPriceByIdAsync(GrpcIntRequest idRequest);
}