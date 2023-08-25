using BH.Backend.Models.Db;

namespace BH.Backend.CustomerService.Service
{
    public class CustomerService : ICustomerService
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer() { ID = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), 
                FirstName = "Parami", LastName = "Modarage" },
            new Customer() { ID = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DB"), 
                FirstName = "Diheesh", LastName = "De Silva" }
        };

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(Guid id)
        {
            return _customers.Where(x => x.ID.Equals(id)).First();
        }
    }
}
