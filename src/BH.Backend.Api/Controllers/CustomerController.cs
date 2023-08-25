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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public CustomerController(
            ICustomerService customerService,
            IAccountService accountService,
            ITransactionService transactionService)
        {
            _customerService = customerService;
            _accountService = accountService;
            _transactionService = transactionService;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.Get();
        }

        [HttpGet("{id}")]
        public CustomerDetailsResponse Get(Guid id)
        {
            var customers = _customerService.Get();
            var customer = customers.Where(m => m.ID.Equals(id)).First();

            var accounts = _accountService.GetByCustomerId(id);
            var accountResponses = new List<AccountDetailsResponse>();

            if (accounts != null)
                foreach (var account in accounts)
                {
                    var transactions = _transactionService.GetByAcccountId(account.ID);

                    var accountDetail = new AccountDetailsResponse()
                    {
                        Account = account
                    };

                    if (transactions != null)
                        accountDetail.Transactions = transactions.ToList();

                    accountResponses.Add(accountDetail);
                }

            return new CustomerDetailsResponse()
            {
                Customer = customer,
                Accounts = accountResponses
            };
        }
    }
}
