using BH.Backend.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Backend.AccountService.Service
{
    public interface IAccountService
    {
        public Account Get(Guid id);

        public IEnumerable<Account> GetByCustomerId(Guid customerId);

        public void Add(Account account);
    }
}
