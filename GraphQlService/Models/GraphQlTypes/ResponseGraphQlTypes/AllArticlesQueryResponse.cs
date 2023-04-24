using Newtonsoft.Json;
using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

public class AllArticlesQueryResponse
{
    [JsonProperty("allArticles")]
    public List<Article> Articles { get; set; }

}
