using GithubSearch.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public interface ISearchRepositoriesInteractor
    {
        Task<List<RepositoryItem>> Handle(SearchRepositoriesRequest input, CancellationToken cancellationToken);
    }
}