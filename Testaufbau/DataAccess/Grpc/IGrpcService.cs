using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    GrpcArticlesResponse GetArticles(GrpcTakeRequest request);
    Article? GetArticleById(GrpcIntRequest intRequest);
    GrpcArticlesResponse GetAllArticles();
    Article? GetArticleBySku(GrpcIntRequest skuRequest);
    Price? GetPriceById(GrpcIntRequest idRequest);
}