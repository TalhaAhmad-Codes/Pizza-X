using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Employee
{
    public sealed class CNIC
    {
        // Attribute
        public string Value { get; }
        
        // Constructos
        private CNIC() { }
        private CNIC(string value)
        {
            Guard.AgainstInvalidRegexPattern(RegexPattern.CNIC, value, nameof(CNIC));

            Value = value;
        }

        // Comparision operator
        public static bool operator ==(CNIC cnic, string other)
            => cnic.Value == other;

        public static bool operator !=(CNIC cnic, string other)
            => cnic.Value != other;

        // Method - Create new object
        public static CNIC Create(string cnic)
            => new(cnic);
    }
}
