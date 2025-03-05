using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);

        RuleFor(x => x.Size).InclusiveBetween(1, 100);
    }
}
