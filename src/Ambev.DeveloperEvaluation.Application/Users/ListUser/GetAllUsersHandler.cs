using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.ListUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUser;

public class GetAllUsersHandler(IUserRepository _userRepository, IMapper _mapper) : IRequestHandler<GetAllUsersCommand, PaginatedResponse<GetUserResult>>
{
    public async Task<PaginatedResponse<GetUserResult>> Handle(GetAllUsersCommand comand, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(comand.Page, comand.Size, comand.Order, cancellationToken);

        var totalUsers = await _userRepository.CountAsync(cancellationToken);

        return new PaginatedResponse<GetUserResult>
        {
            Items = _mapper.Map<List<GetUserResult>>(users),
            TotalItems = totalUsers,
            PageNumber = comand.Page,
            PageSize = comand.Size
        };
    }
}
