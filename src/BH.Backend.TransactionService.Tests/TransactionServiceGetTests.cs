using BH.Backend.TransactionService.DataAccess;
using BH.Backend.TransactionService.Tests.Mock;
using Moq;
using service = BH.Backend.TransactionService.Service;

namespace BH.Backend.TransactionService.Tests
{
    public class TransactionServiceGetTests
    {
        [Fact]
        public void GetByID_Test()
        {
            var transaction = TransactionServiceMock.ValidTransactions.First();
            var repositoryMock = new Mock<ITransactionRepository>();
            repositoryMock.Setup(u => u.GetById(transaction.ID)).Returns(transaction);

            var srvice = new service.TransactionService(repositoryMock.Object);
            var result = srvice.Get(transaction.ID);

            Assert.NotNull(result);
            Assert.Equal(transaction.ID, result.ID);
        }

        [Fact]
        public void GetByAccountID_Test()
        {
            var transaction = TransactionServiceMock.ValidTransactions.First();
            var repositoryMock = new Mock<ITransactionRepository>();
            repositoryMock.Setup(u => u.GetByAccountId(transaction.AccountId))
                .Returns(TransactionServiceMock.ValidTransactions);

            var srvice = new service.TransactionService(repositoryMock.Object);
            var result = srvice.GetByAcccountId(transaction.AccountId);

            Assert.NotNull(result);
            Assert.Equal(transaction.ID, result.First().ID);
        }
    }
}
