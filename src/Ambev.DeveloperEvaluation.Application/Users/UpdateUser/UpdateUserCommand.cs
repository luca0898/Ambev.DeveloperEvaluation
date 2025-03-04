using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public sealed record UpdateUserCommand(
        Guid Id,
        string Username,
        string Password,
        string Phone,
        string Email,
        string FirstName,
        string LastName,
        AddressDetail Address,
        UserStatus Status,
        UserRole Role
    ) : IRequest<UpdateUserResult>
    {
    }

    public class AddressDetail
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Zipcode { get; set; } = string.Empty;
        public GeolocationDetail Geolocation { get; set; } = new GeolocationDetail();
    }

    public class GeolocationDetail
    {
        public string Lat { get; set; } = string.Empty;
        public string Long { get; set; } = string.Empty;
    }
}
