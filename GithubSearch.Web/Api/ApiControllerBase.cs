using GithubSearch.Web.Filters;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GithubSearch.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = IdentityServerConstants.LocalApi.AuthenticationScheme)]
    [ServiceFilter(typeof(ValidationActionFilter))]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
