namespace BH.Backend.Models.Db
{
    public class Customer
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
