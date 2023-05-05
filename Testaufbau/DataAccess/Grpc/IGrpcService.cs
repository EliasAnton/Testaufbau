using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    Task<GrpcArticlesResponse> GetArticlesAsync(GrpcTakeRequest request);
    Task<Article?> GetArticleAsync(GrpcIdRequest idRequest);
    Task<GrpcArticlesResponse> GetAllArticlesAsync();
    Task<GrpcOrdersResponse> GetOrdersAsync(GrpcTakeRequest request);
    Task<GrpcOrdersResponse> GetOrderAsync(GrpcIdRequest idRequest);
    Task<GrpcOrdersResponse> GetAllOrdersAsync();
}