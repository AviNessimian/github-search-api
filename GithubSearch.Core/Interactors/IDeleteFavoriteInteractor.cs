using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public interface IDeleteFavoriteInteractor
    {
        Task<bool> Handle(int id, CancellationToken cancellationToken);
    }
}