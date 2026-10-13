using System.ComponentModel.DataAnnotations;

namespace BankApi.Dtos
{
    public class UpdateAccountDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 1000000000)]
        public decimal Balance { get; set; }

    }
}
