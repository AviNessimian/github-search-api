using GithubSearch.Core.Models;
using System.Collections.Generic;

namespace GithubSearch.Infrastructure.Services
{
    public class GitHubRepoResponse
    {
        public int Total_count { get; set; }
        public bool Incomplete_results { get; set; }
        public List<RepositoryItem> Items { get; set; }
    }
}



