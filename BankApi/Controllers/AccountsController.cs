using BankApi.Dtos;
using BankApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var result = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateAccountDto dto)
        {

            return Ok();
        }

    }
}
