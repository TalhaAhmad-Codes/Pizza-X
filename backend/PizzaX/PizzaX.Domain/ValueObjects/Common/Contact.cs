using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Common
{
    public sealed class Contact
    {
        // Attribute
        public string Value { get; }

        // Constructors
        private Contact() { }
        private Contact(string value)
        {
            Guard.AgainstNullOrWhitespace(value, nameof(Contact));
            Guard.AgainstInvalidRegexPattern(RegexPattern.ContactNumber, value, nameof(Contact));

            Value = Function.Simplify(value)!;
        }

        // Method - Create new object
        public static Contact Create(string number)
            => new(number);

        // Methods - Comparision
        public static bool operator ==(Contact contact, string other)
            => contact.Value == other;

        public static bool operator !=(Contact contact, string other)
            => contact.Value != other;

        // Method - To string
        public override string ToString()
            => Value;
    }
}
