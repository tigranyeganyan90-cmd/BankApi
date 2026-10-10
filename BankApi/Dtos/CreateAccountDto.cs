namespace BankApi.Dtos
{
    public class CreateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
