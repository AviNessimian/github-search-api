using GithubSearch.Core.Entites;
using GithubSearch.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public interface IGetFavoritesInteractor
    {
        Task<List<FavoriteEntity>> Handle(CancellationToken cancellationToken);

        Task<RepositoryItem> Handle(int id, CancellationToken cancellationToken);

        Task<FavoriteEntity> Handle(string fullName, CancellationToken cancellationToken);
    }
}