using GithubSearch.Core.Entites;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public interface IAddFavoriteInteractor
    {
        Task<FavoriteEntity> Handle(AddFavoriteRequest input, CancellationToken cancellationToken);
    }
}