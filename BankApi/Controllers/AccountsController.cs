using BankApi.Dtos;
using BankApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly BankApiContext _context;
        public AccountsController(BankApiContext context)  
        {
            _context = context;                            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.Accounts.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateAccountDto dto)
        {
            var newAccount = new Account
            {
                Name = dto.Name,
                Balance = dto.Balance,
            };
            
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return Ok(newAccount);
        }
    }
}
