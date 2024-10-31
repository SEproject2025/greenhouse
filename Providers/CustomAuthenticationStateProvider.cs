using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace greenhouse.Providers // Adjust the namespace as necessary
{
    // Example of a custom authentication state provider
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;

            return Task.FromResult(new AuthenticationState(user));
        }

        public void NotifyUserAuthentication(string userName)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName)
            }, "apiauth"));

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }
    }

}
