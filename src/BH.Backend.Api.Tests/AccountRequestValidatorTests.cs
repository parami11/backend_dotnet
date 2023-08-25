using BH.Backend.Api.Tests.Mock;
using BH.Backend.Api.Validators;
using BH.Backend.Models.Validators;

namespace BH.Backend.Api.Tests
{
    public class AccountRequestValidatorTests
    {
        [Fact]
        public void ValidAccountRequest()
        {
            var validator = new AccountRequestValidator();
            var result = validator.Validate(AccountRequestMock.AccountRequest_Valid);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void InvalidAccountRequest_NegativeCredit()
        {
            var validator = new AccountRequestValidator();
            var result = validator.Validate(AccountRequestMock.AccountRequest_Invalid_NegativeCredit);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void InvalidAccountRequest_EmptyCustomerId()
        {
            var validator = new AccountRequestValidator();
            var result = validator.Validate(AccountRequestMock.AccountRequest_InValid_EmptyCustomerId);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }
    }
}