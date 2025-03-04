using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public sealed class UpdateUserCommand : IRequest<UpdateUserResult>
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public AddressDetail Address { get; set; } = new AddressDetail();
        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }
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
