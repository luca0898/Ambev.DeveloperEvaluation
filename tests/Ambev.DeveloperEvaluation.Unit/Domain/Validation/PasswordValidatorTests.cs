using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class PasswordValidatorTests
{
    private readonly PasswordValidator _validator;

    public PasswordValidatorTests()
    {
        _validator = new PasswordValidator();
    }

    [Fact(DisplayName = "Valid passwords should pass validation")]
    public void Given_ValidPassword_When_Validated_Then_ShouldNotHaveErrors()
    {
        var password = UserTestData.GenerateValidPassword();

        var result = _validator.TestValidate(password);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty password should fail validation")]
    public void Given_EmptyPassword_When_Validated_Then_ShouldHaveError()
    {
        var password = string.Empty;

        var result = _validator.TestValidate(password);

        result.ShouldHaveValidationErrorFor(x => x);
    }
    [Theory(DisplayName = "Password shorter than minimum length should fail validation")]
    [InlineData("Test@1")]
    [InlineData("Pass#2")]
    public void Given_PasswordShorterThanMinimum_When_Validated_Then_ShouldHaveError(string password)
    {
        var result = _validator.TestValidate(password);

        result.ShouldHaveValidationErrorFor(x => x);
    }

    [Fact(DisplayName = "Password without uppercase should fail validation")]
    public void Given_PasswordWithoutUppercase_When_Validated_Then_ShouldHaveError()
    {
        var password = "password@123";

        var result = _validator.TestValidate(password);

        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one uppercase letter.");
    }

    [Fact(DisplayName = "Password without lowercase should fail validation")]
    public void Given_PasswordWithoutLowercase_When_Validated_Then_ShouldHaveError()
    {
        var password = "PASSWORD@123";

        var result = _validator.TestValidate(password);

        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one lowercase letter.");
    }

    [Fact(DisplayName = "Password without numbers should fail validation")]
    public void Given_PasswordWithoutNumber_When_Validated_Then_ShouldHaveError()
    {
        var password = "Password@ABC";

        var result = _validator.TestValidate(password);

        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one number.");
    }

    [Fact(DisplayName = "Password without special characters should fail validation")]
    public void Given_PasswordWithoutSpecialCharacter_When_Validated_Then_ShouldHaveError()
    {
        var password = "Password123";

        var result = _validator.TestValidate(password);

        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one special character.");
    }
}
