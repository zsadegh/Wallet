using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletContext.DB
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options)
        {
        }

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

//dotnet ef migrations add InitialCreate
//dotnet ef database update