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
    }
}
