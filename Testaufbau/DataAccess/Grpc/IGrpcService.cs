using ProtoBuf.Grpc.Configuration;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.Grpc;

[Service]
public interface IGrpcService
{
    //Task<List<Article>> GetAllArticlesAsync();
    //Task<Article?> GetArticleByIdAsync(int id);
    Task<GrpcResponse> GetAllOrdersAsync();
    Task<Address> GetAddressByIdAsync(GrpcRequest request);
}