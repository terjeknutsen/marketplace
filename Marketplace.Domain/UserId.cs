using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public sealed class UserId : Value<UserId>
    {
        private readonly Guid _value;

        public UserId(Guid value) => _value = value;
     

        protected override bool CompareProperties(UserId other)
        {
            return _value.Equals(other._value);
        }
    }
}
