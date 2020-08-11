using GithubSearch.Core.Contracts;
using GithubSearch.Core.Entites;
using GithubSearch.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearch.Core.Interactors
{
    public class GetFavoritesInteractor : IGetFavoritesInteractor
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserService _user;
        private readonly IRepositoriesSearch _repositoriesSearch;

        public GetFavoritesInteractor(
            IApplicationDbContext dbContext,
            IUserService user,
            IRepositoriesSearch repositoriesSearch)
        {
            _dbContext = dbContext;
            _user = user;
            _repositoriesSearch = repositoriesSearch;
        }

        public async Task<List<FavoriteEntity>> Handle(CancellationToken cancellationToken)
        {
            return await _dbContext.Favorites.Where(x => x.CreatedBy == _user.Id).ToListAsync();
        }

        public async Task<RepositoryItem> Handle(int id, CancellationToken cancellationToken)
        {
            var favoriteEntity = await _dbContext.Favorites.FirstOrDefaultAsync(x => x.Id == id);
            if (favoriteEntity == null)
            {
                // ToDo: Custom NotFound Exception
                throw new Exception();
            }

            var result = await _repositoriesSearch.Get(favoriteEntity.RepoFullName, "desc", 1, 1, cancellationToken);
            if (!result.Succeeded)
            {
                // ToDo: Custom NotFound Exception
                throw new Exception();
            }

            return result.Model.FirstOrDefault();
        }

        public async Task<FavoriteEntity> Handle(string fullName, CancellationToken cancellationToken)
        { 
            var favoriteEntity =  await _dbContext.Favorites.FirstOrDefaultAsync(x => x.RepoFullName == fullName);

            if (favoriteEntity == null)
            {
                return new FavoriteEntity();
            }

            return favoriteEntity;
        }



    }
}
