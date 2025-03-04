using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);
        _ = user ?? throw new KeyNotFoundException($"User with id {command.Id} not found");

        user.Update(
            command.Username,
            command.Password,
            command.Phone,
            command.Email,
            command.Status,
            command.Role,
            new NameDto
            {
                Firstname = command.FirstName,
                Lastname = command.LastName
            },
            new AddressDto
            {
                City = command.Address.City,
                Street = command.Address.Street,
                Number = command.Address.Number,
                Zipcode = command.Address.Zipcode,
                Geolocation = new GeolocationDto
                {
                    Lat = command.Address.Geolocation.Lat,
                    Long = command.Address.Geolocation.Long
                }
            }
        );


        var updatedUser = await _userRepository.UpdateAsync(user, cancellationToken);


        return _mapper.Map<UpdateUserResult>(updatedUser);
    }
}
