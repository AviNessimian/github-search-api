using GithubSearch.Core.Common;
using GithubSearch.Core.Contracts;
using GithubSearch.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Infrastructure.Services
{
    public class GitHubHttpService : IRepositoriesSearch
    {
        private readonly IHttpClientFactory _clientFactory;
        public GitHubHttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Result<List<RepositoryItem>>> Get(string name, string order, int page, int perPage, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?q={name}&order={order}&page={page}&per_page={perPage}");
            var client = _clientFactory.CreateClient("github");
            var response = await client.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var gitHubRepoResponse = JsonSerializer.Deserialize<GitHubRepoResponse>(responseString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                return Result<List<RepositoryItem>>.Success(gitHubRepoResponse.Items);
            }

            return Result<List<RepositoryItem>>.Failure();
        }
    }
}
