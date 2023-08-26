using BH.Backend.Models.Db;

namespace BH.Backend.Api.Entities
{
    public class CustomerDetailsResponse
    {
        public Customer Customer { get; set; }

        public List<AccountDetailsResponse> Accounts { get; set; }
    }
}
