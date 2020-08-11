using GithubSearch.Core.Contracts;
using GithubSearch.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public class SearchRepositoriesInteractor : ISearchRepositoriesInteractor
    {
        private readonly IRepositoriesSearch _repositoriesSearch;
        private readonly ILogger<SearchRepositoriesInteractor> _logger;

        public SearchRepositoriesInteractor(
            ILogger<SearchRepositoriesInteractor> logger,
            IRepositoriesSearch repositoriesSearch)
        {
            _repositoriesSearch = repositoriesSearch;
            _logger = logger;
        }

        public async Task<List<RepositoryItem>> Handle(SearchRepositoriesRequest input, CancellationToken cancellationToken)
        {
            var searchResult = await _repositoriesSearch.Get(input.Name, input.Order, 1, input.ShowEntries, cancellationToken);
            if (!searchResult.Succeeded)
            {
                //ToDo: Custom Exception
                throw new Exception();
            }

            return searchResult.Model;
        }
    }
}
