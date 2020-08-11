using FluentValidation;
using GithubSearch.Core.Contracts;
using GithubSearch.Core.Exceptions;

namespace GithubSearch.Core.Interactors
{
    public class SearchRepositoriesRequest : IRequestModel
    {
        public string Name { get; set; }
        public string Order { get; set; }
        public int ShowEntries { get; set; }

        public void Validate()
        {
            var validationResult = new SearchRepositoriesRequestValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult.Errors);
            }
        }
    }

    public class SearchRepositoriesRequestValidator : AbstractValidator<SearchRepositoriesRequest>
    {
        public SearchRepositoriesRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Order).NotNull().NotEmpty();
            RuleFor(x => x.ShowEntries).NotEmpty();
        }
    }
}
