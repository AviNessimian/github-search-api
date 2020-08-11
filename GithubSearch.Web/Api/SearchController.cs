using GithubSearch.Core.Interactors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Web.Api
{
    public class SearchController : ApiControllerBase
    {
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken,
            [FromServices] ISearchRepositoriesInteractor interactor,
            [FromQuery] SearchRepositoriesRequest request)
            => Ok(await interactor.Handle(request, cancellationToken));
    }
}
