using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    GrpcArticlesResponse GetArticles(GrpcTakeRequestWithFilter request);
    Article? GetArticleBySku(GrpcIntRequest skuRequest);
    Price? GetPriceById(GrpcIntRequest idRequest);
    GrpcArticlesResponse GetArticlesWithPrice(GrpcTakeRequest request);
    Article? GetArticleWithPriceBySku(GrpcIntRequest skuRequest);
}