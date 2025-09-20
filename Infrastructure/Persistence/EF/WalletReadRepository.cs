using Application.Interface.Repository;
using Domain.Entity;
using Microsoft.VisualBasic;
using Persistence.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.EF
{
    public class WalletReadRepository : IWalletReadRepository
    {
        private readonly WalletDbContext _db;
        public WalletReadRepository(WalletDbContext db)
        {
               _db = db; 
        }
        public async Task<decimal> GetBalanceAsync(Guid walletId)
        {
           return await _db.GetBalanceAsync(walletId);
        }
    }
}
