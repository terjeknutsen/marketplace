﻿using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class Money : Value<Money>
    {
        private const string DefaultCurrency = "EUR";
        private Money(decimal amount, CurrencyDetails currency)
        {
            Amount = amount;
            Currency = currency;
        }
        protected Money(decimal amount,string currencyCode, ICurrencyLookup currencyLookup)
        {
            if (string.IsNullOrEmpty(currencyCode))
                throw new ArgumentNullException(nameof(currencyCode), "Currency code must be specified");

            var currency = currencyLookup.FindCurrency(currencyCode);
            if (!currency.InUse)
                throw new ArgumentException($"Currency {currencyCode} is not valid");
            if (decimal.Round(amount, currency.DecimalPlaces) != amount)
                throw new ArgumentOutOfRangeException(nameof(amount), $"Amount cannot have more than {currency.DecimalPlaces} decimals");
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }
        public CurrencyDetails Currency { get; }

        public Money Add(Money summand) 
        {
            if (Currency != summand.Currency)
                throw new CurrencyMismatchException("Cannot sum amounts with different currencies");
           return new Money(Amount + summand.Amount,Currency);
        }
        public Money Subtract(Money subtrahend) 
        {
            if (Currency != subtrahend.Currency)
                throw new CurrencyMismatchException("Cannot subtract amounts with different currencies");
            return new Money(Amount - subtrahend.Amount,Currency); 
         }
        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);
        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);

        protected override bool CompareProperties(Money other)
        {
            return Amount.Equals(other.Amount) && Currency.Equals(other.Currency);
        }

        public override string ToString() => $"{Currency.CurrencyCode} {Amount}";

        public static Money FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) => new Money(amount,currency,currencyLookup);
        public static Money FromString(string amount, string currency, ICurrencyLookup currencyLookup) => new Money(decimal.Parse(amount),currency,currencyLookup);
    }

    public sealed class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message)
        {}
    }
}
