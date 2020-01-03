using Should;
using NUnit.Framework;
using Marketplace.Domain;
using SpecsFor.StructureMap;
using SpecsFor.Core;

namespace Marketplace.Tests.Domain
{
    class MoneySpecs
    {
        class When_compare_money_with_same_amount : SpecsFor<MoneyWrapper>
        {
            private Money a;
            private Money b;

            protected override void Given()
            {
                Given<CurrencyLookupSetup>();
                base.Given();
            }
            protected override void When()
            {
                a = SUT.Create(100, "NOK");
                b = SUT.Create(100,"NOK");
            }
            [Test]
        public void Then_money_objects_should_be_equal(){
                a.ShouldEqual(b);
        }
        }

        class When_sum_money : SpecsFor<MoneyWrapper>
        {
            private Money coin1;
            private Money coin2;
            private Money coin3;

            protected override void Given()
            {
                Given<CurrencyLookupSetup>();
                base.Given();
            }
            protected override void When()
            {
                coin1 = SUT.Create("1", "NOK");
                coin2 = SUT.Create("2", "NOK");
                coin3 = SUT.Create(2, "NOK");
            }
            [Test]
            public void Then_sum_given_full_amount(){

                var sum = SUT.Create(5, "NOK");
                sum.ShouldEqual(coin1 + coin2 + coin3);
            }
        }

        class When_compare_money_with_different_currencies : SpecsFor<MoneyWrapper>{
            private Money a;
            private Money b;

            protected override void Given()
            {
                Given<CurrencyLookupSetup>();
                base.Given();
            }
            protected override void When()
            {
                a = SUT.Create(100, "NOK");
                b = SUT.Create(100, "SEK");
            }
            [Test]
            public void Then_money_objects_should_not_be_equal(){
                a.ShouldNotEqual(b);
            }
        }
        class CurrencyLookupSetup : IContext<MoneyWrapper>
        {
            public void Initialize(ISpecs<MoneyWrapper> state)
            {
                state.GetMockFor<ICurrencyLookup>().Setup(l => l.FindCurrency("NOK"))
                .Returns(new CurrencyDetails { CurrencyCode = "NOK", DecimalPlaces = 2, InUse = true });
                state.GetMockFor<ICurrencyLookup>().Setup(l => l.FindCurrency("SEK"))
                .Returns(new CurrencyDetails { CurrencyCode = "SEK", DecimalPlaces = 2, InUse = true });
            }
        }

        class MoneyWrapper
        {
            private readonly ICurrencyLookup currencyLookup;

            public MoneyWrapper(ICurrencyLookup currencyLookup)
            {
                this.currencyLookup = currencyLookup;
            }
            public Money Create(decimal amount, string currency){
                return Money.FromDecimal(amount, currency, currencyLookup);
            }
            public Money Create(string amount, string currency){
                return Money.FromString(amount, currency, currencyLookup);
            }
        }

    }
}
