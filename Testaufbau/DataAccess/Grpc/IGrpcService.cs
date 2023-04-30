using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    Task<GrpcArticlesResponse> GetAllArticlesAsync();
    Task<Article?> GetArticleByIdAsync(GrpcIdRequest idRequest);
    Task<GrpcOrderResponse> GetAllOrdersAsync();
    Task<Address?> GetAddressByIdAsync(GrpcIdRequest idRequest);
    Task<GrpcArticlesResponse> GetArticlesAsync(GrpcArticlesRequest request);
}