namespace BankApi.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<AccountDto> Accounts { get; set; } = new(); 
    }
}
