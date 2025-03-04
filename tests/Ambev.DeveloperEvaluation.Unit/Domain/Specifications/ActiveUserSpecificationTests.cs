using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    public class ActiveUserSpecificationTests
    {
        [Theory]
        [InlineData(UserStatus.Active, true)]
        [InlineData(UserStatus.Inactive, false)]
        [InlineData(UserStatus.Suspended, false)]
        public void IsSatisfiedBy_ShouldValidateUserStatus(UserStatus status, bool expectedResult)
        {

            var user = ActiveUserSpecificationTestData.GenerateUser(status);
            var specification = new ActiveUserSpecification();
            var result = specification.IsSatisfiedBy(user);
            result.Should().Be(expectedResult);
        }
    }
}
