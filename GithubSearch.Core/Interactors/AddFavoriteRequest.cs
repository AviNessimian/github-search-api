using FluentValidation;
using GithubSearch.Core.Contracts;
using GithubSearch.Core.Exceptions;

namespace GithubSearch.Core.Interactors
{
    public class AddFavoriteRequest: IRequestModel
    {
        public string FullName { get; set; }

        public void Validate()
        {
            var validationResult = new AddFavoriteRequestValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult.Errors);
            }
        }
    }

    public class AddFavoriteRequestValidator : AbstractValidator<AddFavoriteRequest>
    {
        public AddFavoriteRequestValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty();
        }
    }

}
