using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class UserTests
{
    [Fact(DisplayName = "User status should change to Active when activated")]
    public void Given_SuspendedUser_When_Activated_Then_StatusShouldBeActive()
    {
        var user = UserTestData.GenerateValidUser();
        user.Status = UserStatus.Suspended;
        
        user.Activate();
        
        Assert.Equal(UserStatus.Active, user.Status);
    }
    [Fact(DisplayName = "User status should change to Suspended when suspended")]
    public void Given_ActiveUser_When_Suspended_Then_StatusShouldBeSuspended()
    {
        var user = UserTestData.GenerateValidUser();
        
        user.Status = UserStatus.Active;
        
        user.Suspend();
        
        Assert.Equal(UserStatus.Suspended, user.Status);
    }
    [Fact(DisplayName = "Validation should pass for valid user data")]
    public void Given_ValidUserData_When_Validated_Then_ShouldReturnValid()
    {
        var user = UserTestData.GenerateValidUser();

        var result = user.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
    [Fact(DisplayName = "Validation should fail for invalid user data")]
    public void Given_InvalidUserData_When_Validated_Then_ShouldReturnInvalid()
    {
        var user = new User
        {
            Username = "",
            Password = UserTestData.GenerateInvalidPassword(),
            Email = UserTestData.GenerateInvalidEmail(),
            Phone = UserTestData.GenerateInvalidPhone(),
            Status = UserStatus.Unknown,
            Role = UserRole.None
        };
        
        var result = user.Validate();
        
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
