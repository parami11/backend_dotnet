using BH.Backend.Models.Tests.Mock;
using BH.Backend.Models.Validators;

namespace BH.Backend.Models.Tests
{
    public class AccountEntityTests
    {
        [Fact]
        public void ValidAccount()
        {
            var validator = new AccountEntityValidator();
            var result = validator.Validate(AccountMock.Account_Valid);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void InvalidAccount_AccountNumberLength()
        {
            var validator = new AccountEntityValidator();
            var result = validator.Validate(AccountMock.Account_Invalid_InvalidAccountNumber);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void InvalidAccount_AccountNumberEmpty()
        {
            var validator = new AccountEntityValidator();
            var result = validator.Validate(AccountMock.Account_Invalid_EmptyAccountNumber);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void InvalidAccount_NegativeBalance()
        {
            var validator = new AccountEntityValidator();
            var result = validator.Validate(AccountMock.Account_Invalid_NegativeBalance);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void InvalidAccount_EmptyCustomerId()
        {
            var validator = new AccountEntityValidator();
            var result = validator.Validate(AccountMock.Account_Invalid_EmptyCustomerId);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }
    }
}
