using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public record Money(decimal Amount, string Currency = "Rial")
    {
        public Money Add(Money other)
        {
            if (Currency != other.Currency) throw new InvalidOperationException("Currency is wrong");
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            if (Currency != other.Currency) throw new InvalidOperationException("Currency is wrong");
            if (Amount < other.Amount) throw new InvalidOperationException("Insufficient amount");
            return new Money(Amount - other.Amount, Currency);
        }
    }
}
