using GithubSearch.Core.Interactors;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ISearchRepositoriesInteractor, SearchRepositoriesInteractor>();
            services.AddTransient<IAddFavoriteInteractor, AddFavoriteInteractor>();
            services.AddTransient<IGetFavoritesInteractor, GetFavoritesInteractor>();
            services.AddTransient<IDeleteFavoriteInteractor, DeleteFavoriteInteractor>();

            return services;
        }
    }
}
