using BH.Backend.AccountService.Service;
using BH.Backend.Api.Entities;
using BH.Backend.CustomerService.Service;
using BH.Backend.Models.Db;
using BH.Backend.TransactionService.Service;
using Microsoft.AspNetCore.Mvc;

namespace BH.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;

        public AccountController(
            IAccountService accountService,
            ICustomerService customerService,
            ITransactionService transactionService)
        {
            _accountService = accountService;
            _customerService = customerService;
            _transactionService = transactionService;
        }

        [HttpPost]
        public Guid Post([FromBody] AccountRequest accountOpening)
        {
            // Check existence of customer
            var customers = _customerService.Get();
            var customer = customers.Where(m => m.ID.Equals(accountOpening.CustomerId)).First();

            var account = new Account()
            {
                CustomerId = accountOpening.CustomerId,
                CurrentBalance = accountOpening.InitialCredit,
                AccountNumber = (new Random()).Next(100000, 999999).ToString()
            };
            _accountService.Add(account);

            if(accountOpening.InitialCredit > 0)
            {
                var transaction = new Transaction()
                {
                    AccountId = account.ID,
                    TransactionType = Models.Enums.TransactionType.Debit,
                    Amount = accountOpening.InitialCredit
                };
                
                _transactionService.Add(transaction);
            }

            return account.ID;
        }
    }
}
