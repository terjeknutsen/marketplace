using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public sealed class ClassifiedAdText : Value<ClassifiedAdText>
    {
        private readonly string value;

        internal ClassifiedAdText(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Text cannot be empty");
            this.value = value;
        }
        protected override bool CompareProperties(ClassifiedAdText other)
        {
            return value.Equals(other.value);
        }

        public static ClassifiedAdText FromString(string text) => new ClassifiedAdText(text);
        public static implicit operator string(ClassifiedAdText self) => self.value;
    }
}
