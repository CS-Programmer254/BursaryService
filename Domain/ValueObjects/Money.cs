using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Domain.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        private Money() { }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)

                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            if (string.IsNullOrWhiteSpace(currency))

                throw new ArgumentException("Currency cannot be empty.", nameof(currency));
            
            Amount = amount;
            
            Currency = currency.ToUpper(); 
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)

                throw new InvalidOperationException("Cannot add different currencies.");

            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            if (Currency != other.Currency)

                throw new InvalidOperationException("Cannot subtract different currencies.");

            if (Amount < other.Amount)

                throw new InvalidOperationException("Insufficient balance.");

            return new Money(Amount - other.Amount, Currency);
        }

        public bool Equals(Money other)
        {

            if (other == null) return false;

            return Amount == other.Amount && Currency == other.Currency;

        }

        public override bool Equals(object obj) => Equals(obj as Money);

        public override int GetHashCode() => HashCode.Combine(Amount, Currency);

        public override string ToString() => $"{Currency} {Amount:N2}";
    }
}
