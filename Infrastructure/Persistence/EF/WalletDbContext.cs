using Application.Interface.Repository;
using Azure;
using Azure.Core;
using Domain.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DB
{
    public class WalletDbContext : DbContext, IWalletReadRepository, IWalletRepository
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options)
        {
        }

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public async Task<decimal> GetBalanceAsync(Guid walletId)
        {
            var result = await Wallet.FindAsync(walletId);
            return result == null ? 0 : result.Balance.Amount;
        }

        public async Task<Wallet> GetByIdAsync(Guid id) => await Wallet.FindAsync(id);
        public async Task SaveAsync(Wallet wallet)
        {
            Wallet.Add(wallet);
            await SaveChangesAsync();
        }
    }
}

//dotnet ef migrations add InitialCreate
//dotnet ef database update