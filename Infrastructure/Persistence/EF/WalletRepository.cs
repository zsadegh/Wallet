using Application.Interface.Repository;
using Domain.Entity;
using Persistence.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletDbContext _db;
        public WalletRepository(WalletDbContext db)
        {
            _db = db;
        }
        public async Task<Wallet> GetByIdAsync(Guid id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task SaveAsync(Wallet wallet)
        {
            await _db.SaveAsync(wallet);
        }
    }
}
