using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BankApi.Dtos
{
    public class PatchAccountDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }
        [Range(typeof(decimal), "0", "100000000")]
        public decimal? Balance { get; set; }
    }
}
