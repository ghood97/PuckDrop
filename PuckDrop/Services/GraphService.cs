using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace PuckDrop.Services;

public interface IGraphService
{
    Task<User?> GetProfileAsync();
}

public class GraphService : IGraphService
{
    private const string UPN_CLAIM_TYPE = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
    private readonly IUserContext _userContext;

    public GraphServiceClient GraphClient { get; }

    public GraphService(GraphServiceClient graphClient, IUserContext userContext)
    {
        GraphClient = graphClient;
        _userContext = userContext;
    }

    public async Task<User?> GetProfileAsync()
    {
        var user = await _userContext.GetCurrentUserAsync();
        string? upn = user.Claims.FirstOrDefault(c => c.Type == UPN_CLAIM_TYPE)?.Value;
        User? currentGraphUser = null;
        if (upn is not null)
        {
            currentGraphUser = await GraphClient.Users[upn].GetAsync();
        }
        return currentGraphUser;
    }
}
