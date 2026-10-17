using BankApi.Dtos;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly BankApiContext _context;
        public CustomersController(BankApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Customers.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            var newCustomer = new Customer
            {
                FullName = dto.FullName,
                Phone = dto.Phone
            };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerDto dto)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            result.FullName = dto.FullName;
            result.Phone = dto.Phone;
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUpdate(int id, PatchCustomerDto dto)
        {

            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            if (dto.FullName != null)
            {
                result.FullName = dto.FullName;
            }
            if (dto.Phone != null)
            {
                result.Phone = dto.Phone;
            }
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
