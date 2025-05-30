using FluentValidation;

namespace interview_tallertechnologies.Application.UseCases.User.v1.Queries
{
    public class GetUserByUserNameQueryValidator : AbstractValidator<GetUserByUserNameQuery>
    {
        public GetUserByUserNameQueryValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
        }
    }
}
