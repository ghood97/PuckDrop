using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace PuckDrop.Services;

public interface IUserContext
{
    Task<ClaimsPrincipal> GetCurrentUserAsync();
}

public class UserContext : IUserContext
{
    private readonly AuthenticationStateProvider _authState;

    public UserContext(AuthenticationStateProvider authState)
    {
        _authState = authState;
    }

    public async Task<ClaimsPrincipal> GetCurrentUserAsync()
    {
        return (await _authState.GetAuthenticationStateAsync()).User;
    }
}
