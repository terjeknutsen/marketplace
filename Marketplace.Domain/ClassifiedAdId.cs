using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public sealed class ClassifiedAdId : Value<ClassifiedAdId>
    {
        private readonly Guid _value;

        public ClassifiedAdId(Guid value) => _value = value;

        protected override bool CompareProperties(ClassifiedAdId other)
        {
            return _value.Equals(other._value);
        }
    }
}
