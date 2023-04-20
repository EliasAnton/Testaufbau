using System.Security.Claims;

namespace GraphQlService.Models;

public class GraphQLUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal User { get; set; }
}