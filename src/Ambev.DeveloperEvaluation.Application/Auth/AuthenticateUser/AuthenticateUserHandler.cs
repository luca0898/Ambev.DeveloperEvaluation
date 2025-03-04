using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public AuthenticateUserHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticateUserResult> Handle(
        AuthenticateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        var activeUserSpec = new ActiveUserSpecification();
        if (!activeUserSpec.IsSatisfiedBy(user))
            throw new UnauthorizedAccessException("User is not active");

        return new AuthenticateUserResult
        {
            Token = _jwtTokenGenerator.GenerateToken(user),
            Email = user.Email,
            Name = user.Username,
            Role = user.Role.ToString()
        };
    }
}
