using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

public class GetUserValidator : AbstractValidator<GetUserQuery>
{
    public GetUserValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
