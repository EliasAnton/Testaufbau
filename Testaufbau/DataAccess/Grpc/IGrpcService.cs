using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    Task<GrpcArticlesResponse> GetArticles(GrpcTakeRequestWithFilter request);
    Task<Article?> GetArticleBySku(GrpcIntRequest skuRequest);
    Task<Price?> GetPriceById(GrpcIntRequest idRequest);
    Task<GrpcArticlesResponse> GetArticlesWithPrice(GrpcTakeRequest request);
    Task<Article?> GetArticleWithPriceBySku(GrpcIntRequest skuRequest);
}