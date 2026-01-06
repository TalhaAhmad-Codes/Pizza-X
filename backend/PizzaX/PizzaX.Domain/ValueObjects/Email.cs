using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects
{
    public sealed class Email
    {
        // Attribute
        public string Value { get; }

        // Constructor
        public Email(string email)
        {
            // Guard against invalid value
            Guard.AgainstNullOrWhitespace(email, "Email");

            Value = email;
        }

        // Method - Create a new object
        public static Email Create(string email)
            => new(email);

        // Method - Convert to string
        public override string ToString()
            => Value;
    }
}
