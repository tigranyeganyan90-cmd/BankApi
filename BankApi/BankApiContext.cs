using BankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApi
{
    public class BankApiContext : DbContext
    {
        DbSet<Account> Accounts { get; set; }
        public BankApiContext(DbContextOptions<BankApiContext> options) : base(options)
        { 
            
        }
    }
}
