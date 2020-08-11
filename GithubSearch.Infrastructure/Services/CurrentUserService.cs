using GithubSearch.Core.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GithubSearch.Infrastructure.Services
{
    public class CurrentUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Id => _httpContextAccessor.HttpContext.User.FindFirst("sub")?.Value;
        public string Name => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        public string Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
    }
}
