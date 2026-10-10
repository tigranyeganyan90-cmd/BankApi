using BankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApi
{
    public class BankApiContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public BankApiContext(DbContextOptions<BankApiContext> options) : base(options)
        { 
            
        }
    }
}
