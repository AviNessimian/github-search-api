using GithubSearch.Core.Common;

namespace GithubSearch.Core.Entites
{
    public class FavoriteEntity : AuditableEntity
    {
        public int Id { get; set; }
        public string RepoFullName { get; set; }
    }
}
