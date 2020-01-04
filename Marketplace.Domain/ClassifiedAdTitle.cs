using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public sealed class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        private readonly string value;
        internal ClassifiedAdTitle(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException("Title cannot be longer than 100 characters", nameof(value));
            this.value = value;
        }
        protected override bool CompareProperties(ClassifiedAdTitle other)
        {
            return value.Equals(other.value);
        }

        public static ClassifiedAdTitle FromString(string title) => new ClassifiedAdTitle(title);
        public static implicit operator string(ClassifiedAdTitle self)=> self.value;

    }
}
