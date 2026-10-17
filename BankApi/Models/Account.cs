namespace BankApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
