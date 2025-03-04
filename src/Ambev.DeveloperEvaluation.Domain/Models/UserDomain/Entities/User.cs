using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities
{
    public class User : BaseEntity, IUser
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
            Name = new NameDto();
            Address = new AddressDto();
        }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public UserStatus Status { get; set; }
        public NameDto Name { get; set; } = new NameDto();
        public AddressDto Address { get; set; } = new AddressDto();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        string IUser.Id => Id.ToString();
        string IUser.Username => Username;
        string IUser.Role => Role.ToString();

        public ValidationResultDetail Validate()
        {
            var validator = new UserValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Activate()
        {
            Status = UserStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = UserStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Suspend()
        {
            Status = UserStatus.Suspended;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Update(string username, string password, string phone, string email, UserStatus status, UserRole role, NameDto name, AddressDto address)
        {
            Username = username;
            Password = password;
            Phone = phone;
            Email = email;
            Status = status;
            Role = role;
            Name = name;
            Address = address;

            Activate();
        }
    }

}
