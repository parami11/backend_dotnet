using BH.Backend.AccountService.Service;
using BH.Backend.Api.Controllers;
using BH.Backend.Api.Tests.Mock;
using BH.Backend.Api.Validators;
using BH.Backend.CustomerService.Service;
using BH.Backend.TransactionService.Service;
using FluentValidation;
using Moq;

namespace BH.Backend.Api.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public void InvalidRequest()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => PostAction_InvalidRequest());
        }

        private static void PostAction_InvalidRequest()
        {
            var accountServiceMock = new Mock<IAccountService>();
            var customerServiceMock = new Mock<ICustomerService>();
            var transactionServiceMock = new Mock<ITransactionService>();
            var accountRequestValidator = new AccountRequestValidator();

            var accountController = new AccountController(
                accountServiceMock.Object, customerServiceMock.Object,
                transactionServiceMock.Object, accountRequestValidator);

            accountController.Post(AccountRequestMock.AccountRequest_Invalid_NegativeCredit);
        }
    }
}
