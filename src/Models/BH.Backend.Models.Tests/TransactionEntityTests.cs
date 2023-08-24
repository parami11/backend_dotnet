using BH.Backend.Models.Tests.Mock;
using BH.Backend.Models.Validators;

namespace BH.Backend.Models.Tests
{
    public class TransactionEntityTests
    {
        [Fact]
        public void ValidTransaction()
        {
            var validator = new TransactionEntityValidator();
            var result = validator.Validate(TransactionMock.Transaction_Valid);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void InvalidTransaction_InvalidTransactionType()
        {
            var validator = new TransactionEntityValidator();
            var result = validator.Validate(TransactionMock.Transaction_Invalid_InvalidType);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void InvalidTransaction_InvalidAmount()
        {
            var validator = new TransactionEntityValidator();
            var result = validator.Validate(TransactionMock.Transaction_Invalid_Amount);
            Assert.False(result.IsValid);
        }
    }
}
