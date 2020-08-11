using GithubSearch.Core.Entites;
using GithubSearch.Core.Interactors;
using GithubSearch.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace GithubSearch.Web.Api
{
    public class FavoritesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<FavoriteEntity>>> Get(
            CancellationToken cancellationToken,
            [FromServices] IGetFavoritesInteractor interactor) => Ok(await interactor.Handle(cancellationToken));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RepositoryItem>> Get(
            CancellationToken cancellationToken,
            [FromServices] IGetFavoritesInteractor interactor,
            int id) => Ok(await interactor.Handle(id, cancellationToken));

        [HttpGet("isfavorite/{id}")]
        public async Task<ActionResult<FavoriteEntity>> Get(
            CancellationToken cancellationToken,
            [FromServices] IGetFavoritesInteractor interactor,
            string id)
        {
            return Ok(await interactor.Handle(System.Web.HttpUtility.UrlDecode(id), cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteEntity>> Post(
            CancellationToken cancellationToken,
            [FromServices] IAddFavoriteInteractor interactor,
            [FromBody] AddFavoriteRequest request)
        {
            var favoriteEntity = await interactor.Handle(request, cancellationToken);
            return Ok(favoriteEntity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
            CancellationToken cancellationToken,
            [FromServices] IDeleteFavoriteInteractor interactor,
            int id)
        {
            var result = await interactor.Handle(id, cancellationToken);
            if (result) return Ok();
            return BadRequest();
        }
    }
}
