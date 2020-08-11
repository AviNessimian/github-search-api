using GithubSearch.Core.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public class DeleteFavoriteInteractor : IDeleteFavoriteInteractor
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteFavoriteInteractor(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(int id, CancellationToken cancellationToken)
        {
            var itemToRemove = _dbContext.Favorites.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _dbContext.Favorites.Remove(itemToRemove);
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            }

            return false;
        }

    }
}
