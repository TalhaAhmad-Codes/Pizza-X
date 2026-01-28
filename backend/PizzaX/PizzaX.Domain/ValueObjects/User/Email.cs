using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.User
{
    public sealed class Email
    {
        // Attribute
        public string Value { get; }

        // Constructors
        private Email() { }
        private Email(string email)
        {
            // Guard against invalid value
            Guard.AgainstNullOrWhitespace(email, "Email");
            Guard.AgainstInvalidRegexPattern(RegexPattern.Email, email, nameof(email));

            Value = Function.Simplify(email)!;
        }

        // Method - Create a new object
        public static Email Create(string email)
            => new(email);

        // Method - Convert to string
        public override string ToString()
            => Value;
    }
}
