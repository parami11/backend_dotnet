using BH.Backend.Models.Db;
using BH.Backend.Models.Tests.Mock;
using BH.Backend.TransactionService.DataAccess;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace BH.Backend.TransactionService.Tests
{
    public class TransactionRepositoryTests
    {
        [Fact]
        public void Post_InvalidTransaction()
        {
            var exception = Assert.Throws<NullReferenceException>(() => PostAction_InvalidTransaction());
        }

        private static void PostAction_InvalidTransaction()
        {
            var memoryCache = new Mock<IMemoryCache>();
            var validator = new Mock<IValidator<Transaction>>();

            var repository = new TransactionRepository(memoryCache.Object, validator.Object);
            repository.AddValue(TransactionMock.Transaction_Invalid_EmptyAccountId);
        }
    }
}
