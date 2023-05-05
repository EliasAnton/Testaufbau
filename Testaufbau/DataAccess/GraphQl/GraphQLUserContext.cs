using System.Security.Claims;

namespace Testaufbau.DataAccess.GraphQl;

public class GraphQlUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal User { get; set; }
}