using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    GrpcArticlesResponse GetArticles(GrpcTakeRequest request, string? filter = null);
    Article? GetArticleById(GrpcIntRequest intRequest);
    GrpcArticlesResponse GetAllArticles();
    Article? GetArticleBySku(GrpcIntRequest skuRequest);
    Price? GetPriceById(GrpcIntRequest idRequest);
    GrpcArticlesResponse GetArticlesWithPrice(GrpcTakeRequest request);
}