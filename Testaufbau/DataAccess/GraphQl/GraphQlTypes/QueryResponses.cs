using System.Text.Json.Serialization;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess.GraphQl.GraphQlTypes;

public class GetArticlesQueryResponse
{
    [JsonPropertyName("getArticles")]
    public List<Article> Articles { get; set; }
}

public class GetArticleBySkuQueryResponse
{
    [JsonPropertyName("getArticleBySku")]
    public Article Article { get; set; }
}

public class GetPriceQueryResponse
{
    [JsonPropertyName("getPriceById")]
    public Price Price { get; set; }
}