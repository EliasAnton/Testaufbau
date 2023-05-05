using System.Text.Json.Serialization;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public class AllArticlesQueryResponse
{
    [JsonPropertyName("allArticles")]
    public List<Article> Articles { get; set; }
}

public class GetArticlesQueryResponse
{
    [JsonPropertyName("getArticles")]
    public List<Article> Articles { get; set; }
}

public class GetArticleQueryResponse
{
    [JsonPropertyName("getArticle")]
    public Article Article { get; set; }
}

public class GetOrdersQueryResponse
{
    [JsonPropertyName("getOrders")]
    public List<Order> Orders { get; set; }
}

public class GetOrderQueryResponse
{
    [JsonPropertyName("getOrder")]
    public Order Order { get; set; }
}

public class getOrderItemsQueryResponse
{
    [JsonPropertyName("getOrderItems")]
    public List<OrderItem> OrderItems { get; set; }
}