using Newtonsoft.Json;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

public class ArticlesQueryResponse
{
    [JsonProperty("allArticles")]
    public List<Article> Articles { get; set; }

}
