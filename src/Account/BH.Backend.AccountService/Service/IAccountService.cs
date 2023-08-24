using BH.Backend.Models.Db;

namespace BH.Backend.AccountService.Service
{
    internal interface IAccountService
    {
        public Account Get(Guid id);

        public IEnumerable<Account> GetByCustomerId(Guid customerId);

        public void Add(Account account);
    }
}
