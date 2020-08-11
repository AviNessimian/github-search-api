using GithubSearch.Core.Contracts;
using GithubSearch.Core.Entites;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public class AddFavoriteInteractor : IAddFavoriteInteractor
    {
        private readonly IApplicationDbContext _dbContext;

        public AddFavoriteInteractor(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FavoriteEntity> Handle(AddFavoriteRequest input, CancellationToken cancellationToken)
        {
            var newFavoriteEntity = new Entites.FavoriteEntity()
            {
                RepoFullName = input.FullName
            };

            _dbContext.Favorites.Add(newFavoriteEntity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return newFavoriteEntity;
        }
    }
}
