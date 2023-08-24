using BH.Backend.AccountService.DataAccess;
using BH.Backend.Models.Tests.Mock;
using Moq;
using service = BH.Backend.AccountService.Service;

namespace BH.Backend.AccountService.Tests
{
    public class AccountServicePostTests
    {
        [Fact]
        public void Post_ValidAccount()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(u => u.AddValue(AccountMock.Account_Valid));

            var accountService = new service.AccountService(accountRepositoryMock.Object);
            accountService.Add(AccountMock.Account_Valid);
        }
    }
}
