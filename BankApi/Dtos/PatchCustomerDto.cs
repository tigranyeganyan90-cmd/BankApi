using System.ComponentModel.DataAnnotations;

namespace BankApi.Dtos
{
    public class PatchCustomerDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string? FullName { get; set; }

        [StringLength(30, MinimumLength = 6)]
        public string? Phone { get; set; }
    }
}
