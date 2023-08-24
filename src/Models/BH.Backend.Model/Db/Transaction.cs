using BH.Backend.Models.Enums;

namespace BH.Backend.Models.Db
{
    public class Transaction
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public TransactionType TransactionType { get; set; }

        public double Amount { get; set; }
    }
}
