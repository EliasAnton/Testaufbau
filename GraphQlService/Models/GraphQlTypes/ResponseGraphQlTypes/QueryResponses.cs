using System.Text.Json.Serialization;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

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
