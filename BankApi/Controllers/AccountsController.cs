using BankApi.Dtos;
using BankApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult GetAll([FromQuery] string? search , [FromQuery] decimal? minBalance)
        {
            var query = _context.Accounts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a => a.Name.Contains(search));
            }
            if (minBalance.HasValue)
            {
                query = query.Where(a => a.Balance >= minBalance);
            }
            var result = query.ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            var exist = await _context.Customers.AnyAsync(c => c.Id == dto.CustomerId);
            if (!exist)
            {
                return BadRequest($"a customer with this {dto.CustomerId} identifier does not exist");
            }
            var newAccount = new Account
            {
                Name = dto.Name,
                Balance = dto.Balance,
                CustomerId = dto.CustomerId 
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();
            return Ok(newAccount);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateAccountDto dto)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            account.Name = dto.Name;
            account.Balance = dto.Balance;
            _context.SaveChanges();
            return Ok(account);
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, PatchAccountDto dto)
        { 
           var account = _context.Accounts.FirstOrDefault(a=>a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            if (dto.Name != null )
            {
                account.Name = dto.Name;
            }
            if (dto.Balance.HasValue)
            {
                account.Balance = dto.Balance.Value;
            }
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return Ok(account);
        }

    }
}
