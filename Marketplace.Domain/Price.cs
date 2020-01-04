﻿using System;

namespace Marketplace.Domain
{
    public sealed class Price : Money
    {
        private Price(decimal amount,string currency, ICurrencyLookup currencyLookup) : base(amount,currency, currencyLookup)
        {
            if (amount < 0)
                throw new ArgumentException("Price cannot be negative", nameof(amount));
        }
        internal Price(decimal amount, string currencyCode) : base(amount, new CurrencyDetails{ CurrencyCode = currencyCode}){ }
        public new static Price FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) => new Price(amount, currency, currencyLookup);
    }
}
