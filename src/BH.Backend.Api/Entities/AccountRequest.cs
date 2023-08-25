namespace BH.Backend.Api.Entities
{
    public class AccountRequest
    {
        public Guid CustomerId { get; set; }

        public double InitialCredit { get; set; }
    }
}
