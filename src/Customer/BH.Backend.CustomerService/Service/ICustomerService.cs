using BH.Backend.Models.Db;

namespace BH.Backend.CustomerService.Service
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> Get();

        public Customer Get(Guid id);
    }
}
