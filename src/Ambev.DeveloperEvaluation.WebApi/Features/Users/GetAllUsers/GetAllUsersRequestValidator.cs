using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUsers;

public class GetAllUsersRequestValidator : AbstractValidator<GetAllUsersRequest>
{
    public GetAllUsersRequestValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);

        RuleFor(x => x.Size).GreaterThan(0);
    }
}
