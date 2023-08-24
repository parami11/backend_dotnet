using BH.Backend.AccountService.DataAccess;
using BH.Backend.AccountService.Tests.Mock;
using BH.Backend.Models.Tests.Mock;
using Moq;
using service = BH.Backend.AccountService.Service;

namespace BH.Backend.AccountService.Tests
{
    public class AccountServiceGetTests
    {
        [Fact]
        public void GetByID_Test()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(u => u.GetValues()).Returns(AccountServiceMock.ValidAccounts);

            var accountService = new service.AccountService(accountRepositoryMock.Object);
            var result = accountService.Get(AccountMock.Account_Valid.ID);

            Assert.NotNull(result);
            Assert.Equal(AccountMock.Account_Valid.ID, result.ID);
        }

        [Fact]
        public void GetByCustomerID_Test()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(u => u.GetValues()).Returns(AccountServiceMock.ValidAccounts);

            var accountService = new service.AccountService(accountRepositoryMock.Object);
            var results = accountService.GetByCustomerId(AccountMock.Account_Valid.CustomerId);

            Assert.NotNull(results);
            Assert.Single(results);
            Assert.Equal(AccountMock.Account_Valid.ID, results.First().ID);
        }
    }
}