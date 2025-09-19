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
        private readonly List<Transaction> _transactions = new();
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        private Wallet() { }

        public Wallet(Guid id)
        {
            Id = id;
            Balance = new Money(0);
        }

        public void Deposit(Money money)
        {
            Balance = Balance.Add(money);
            _transactions.Add(new Transaction(Guid.NewGuid(), money, TransactionType.Deposit));
        }

        public void Withdraw(Money money)
        {
            Balance = Balance.Subtract(money);
            _transactions.Add(new Transaction(Guid.NewGuid(), money, TransactionType.Withdraw));
        }
    }
}
