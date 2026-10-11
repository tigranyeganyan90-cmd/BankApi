namespace BankApi.Dtos
{
    public class UpdateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        
    }
}
