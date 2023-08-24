using BH.Backend.AccountService.DataAccess;
using BH.Backend.Models.Db;
using BH.Backend.Models.Tests.Mock;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace BH.Backend.AccountService.Tests
{
    public class AccountRepositoryTests
    {
        [Fact]
        public void Post_InvalidAccount()
        {
            var exception = Assert.Throws<NullReferenceException>(() => PostAction_InvalidAccount());
        }

        private static void PostAction_InvalidAccount()
        {
            var memoryCache = new Mock<IMemoryCache>();
            var accountValidator = new Mock<IValidator<Account>>();

            var accountRepository = new AccountRepository(memoryCache.Object, accountValidator.Object);
            accountRepository.AddValue(AccountMock.Account_Invalid_InvalidAccountNumber);
        }
    }
}
