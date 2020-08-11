using GithubSearch.Core.Common;
using GithubSearch.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Contracts
{
    public interface IRepositoriesSearch
    {
        Task<Result<List<RepositoryItem>>> Get(string name, string order, int page, int perPage, CancellationToken cancellationToken);
    }
}
