using BH.Backend.AccountService.DataAccess;
using BH.Backend.Models.Db;

namespace BH.Backend.AccountService.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account Get(Guid id)
        {
            var values = _accountRepository.GetValues();
            return values.Where(m => m.ID.Equals(id)).First();
        }

        public IEnumerable<Account> GetByCustomerId(Guid customerId)
        {
            var values = _accountRepository.GetValues();

            if (values != null)
                return values.Where(m => m.CustomerId.Equals(customerId));

            return null;
        }

        public void Add(Account account)
        {
            _accountRepository.AddValue(account);
        }
    }
}
