using System.ComponentModel.DataAnnotations;

namespace BankApi.Dtos
{
    public class UpdateCustomerDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Phone { get; set; } = string.Empty;
    }
}
