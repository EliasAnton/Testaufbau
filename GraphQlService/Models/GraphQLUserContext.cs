using System.Security.Claims;

namespace GraphQlService.Models;

public class GraphQlUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal User { get; set; }
}