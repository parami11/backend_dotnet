using BH.Backend.Models.Db;

namespace BH.Backend.Api.Entities
{
    public class AccountDetailsResponse
    {
        public Account Account { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
