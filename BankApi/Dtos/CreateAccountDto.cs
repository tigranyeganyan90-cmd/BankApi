using System.ComponentModel.DataAnnotations;

namespace BankApi.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 100000000)]
        public decimal Balance { get; set; }
    }
}
