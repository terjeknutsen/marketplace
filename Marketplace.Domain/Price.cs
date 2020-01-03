using System;

namespace Marketplace.Domain
{
    public sealed class Price : Money
    {
        public Price(decimal amount,string currency, ICurrencyLookup currencyLookup) : base(amount,currency, currencyLookup)
        {
            if (amount < 0)
                throw new ArgumentException("Price cannot be negative", nameof(amount));
        }
    }
}
