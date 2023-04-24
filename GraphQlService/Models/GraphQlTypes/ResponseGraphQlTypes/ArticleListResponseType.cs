using Testaufbau.DataAccess.Models;

namespace GraphQlService.Models.GraphQlTypes.ResponseGraphQlTypes;

public class ArticleListResponseType
{
    public List<Article> Articles { get; set; }
}

public class ArticleResponseType
{
    public Article Article { get; set; }
}