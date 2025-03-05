using Ambev.DeveloperEvaluation.Application.Commons;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;

public class GetAllUsersHandler(IUserRepository _userRepository, IMapper _mapper)
    : IRequestHandler<GetAllUsersQuery, PaginatedResult<GetAllUsersResult>>
{
    public async Task<PaginatedResult<GetAllUsersResult>> Handle(GetAllUsersQuery comand, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(comand.Page, comand.Size, comand.Order, cancellationToken);

        var totalUsers = await _userRepository.CountAsync(cancellationToken);

        return new PaginatedResult<GetAllUsersResult>
        {
            Items = _mapper.Map<List<GetAllUsersResult>>(users),
            TotalItems = totalUsers,
            PageNumber = comand.Page,
            PageSize = comand.Size
        };
    }
}
