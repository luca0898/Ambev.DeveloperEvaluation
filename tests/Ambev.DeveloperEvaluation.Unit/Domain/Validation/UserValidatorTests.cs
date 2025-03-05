using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class UserValidatorTests
{
    private readonly UserValidator _validator;

    public UserValidatorTests()
    {
        _validator = new UserValidator();
    }
    [Fact(DisplayName = "Valid user should pass all validation rules")]
    public void Given_ValidUser_When_Validated_Then_ShouldNotHaveErrors()
    {

        var user = UserTestData.GenerateValidUser();
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveAnyValidationErrors();
    }
    [Theory(DisplayName = "Invalid username formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    public void Given_InvalidUsername_When_Validated_Then_ShouldHaveError(string username)
    {

        var user = UserTestData.GenerateValidUser();
        user.Username = username;
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }
    [Fact(DisplayName = "Username longer than maximum length should fail validation")]
    public void Given_UsernameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {

        var user = UserTestData.GenerateValidUser();
        user.Username = UserTestData.GenerateLongUsername();
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }
    [Fact(DisplayName = "Invalid email formats should fail validation")]
    public void Given_InvalidEmail_When_Validated_Then_ShouldHaveError()
    {

        var user = UserTestData.GenerateValidUser();
        user.Email = UserTestData.GenerateInvalidEmail();
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }
    [Fact(DisplayName = "Invalid password formats should fail validation")]
    public void Given_InvalidPassword_When_Validated_Then_ShouldHaveError()
    {

        var user = UserTestData.GenerateValidUser();
        user.Password = UserTestData.GenerateInvalidPassword();
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }
    [Fact(DisplayName = "Invalid phone formats should fail validation")]
    public void Given_InvalidPhone_When_Validated_Then_ShouldHaveError()
    {

        var user = UserTestData.GenerateValidUser();
        user.Phone = UserTestData.GenerateInvalidPhone();
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Phone);
    }

    [Fact(DisplayName = "Unknown status should fail validation")]
    public void Given_UnknownStatus_When_Validated_Then_ShouldHaveError()
    {

        var user = UserTestData.GenerateValidUser();
        user.Status = UserStatus.Unknown;
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Status);
    }

    [Fact(DisplayName = "None role should fail validation")]
    public void Given_NoneRole_When_Validated_Then_ShouldHaveError()
    {

        var user = UserTestData.GenerateValidUser();
        user.Role = UserRole.None;
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(x => x.Role);
    }
}
