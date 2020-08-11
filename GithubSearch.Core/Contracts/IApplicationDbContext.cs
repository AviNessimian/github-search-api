using GithubSearch.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<FavoriteEntity> Favorites { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
