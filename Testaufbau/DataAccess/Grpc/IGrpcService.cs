using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    Task<GrpcArticlesResponse> GetArticlesAsync(GrpcTakeRequest request);
    Task<Article?> GetArticleByIdAsync(GrpcIdRequest idRequest);
    Task<GrpcArticlesResponse> GetAllArticlesAsync();
    Task<GrpcOrdersResponse> GetOrdersAsync(GrpcTakeRequest request);
    Task<GrpcOrdersResponse> GetOrderByIdAsync(GrpcIdRequest idRequest);
    Task<GrpcOrdersResponse> GetAllOrdersAsync();
}