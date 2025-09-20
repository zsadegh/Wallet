using Domain.Common;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Wallet
    {
        public Guid Id { get; private set; }
        public Money Balance { get; private set; }
        private Wallet() { }

        public Wallet(Guid id)
        {
            Id = id;
            Balance = new Money(0);
        }

        public void Deposit(Money money)
        {
            Balance = Balance.Add(money);           
        }

        public void Withdraw(Money money)
        {
            Balance = Balance.Subtract(money);            
        }
        public void Transfer(Wallet targetWallet, Money money)
        {
            if (targetWallet == null)
                throw new ArgumentNullException(nameof(targetWallet));

            if(money.Currency!=Balance.Currency)
                throw new ArgumentException("Transfer currency mismatch");

            if (money.Amount <= 0)
                throw new ArgumentException("Transfer amount must be positive.");

            if (money.Amount > Balance.Amount)
                throw new InvalidOperationException("Insufficient funds for transfer.");

            this.Withdraw(money);
            targetWallet.Deposit(money);
        }
    }
}
