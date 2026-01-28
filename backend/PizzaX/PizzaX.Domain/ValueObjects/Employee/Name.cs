using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Employee
{
    public sealed class Name
    {
        // Attributes
        public string FirstName { get; }
        public string? MidName { get; }
        public string LastName { get; }
        public string FatherName { get; }

        // Constructors
        private Name() { }
        private Name(string firstName, string? midName, string lastName, string fatherName)
        {
            Guard.AgainstNullOrWhitespace(firstName, nameof(FirstName));
            Guard.AgainstWhitespace(midName, nameof(MidName));
            Guard.AgainstNullOrWhitespace(lastName, nameof(LastName));

            var regexMessage = "It can only contain alphabets.";
            Guard.AgainstInvalidRegexPattern(RegexPattern.SingleName, firstName, nameof(FirstName), regexMessage);
            Guard.AgainstInvalidRegexPattern(RegexPattern.SingleName, midName!, nameof(MidName), regexMessage);
            Guard.AgainstInvalidRegexPattern(RegexPattern.SingleName, lastName, nameof(LastName), regexMessage);
            Guard.AgainstInvalidRegexPattern(RegexPattern.FullName, fatherName, nameof(FatherName), regexMessage);

            FirstName = Function.Simplify(firstName)!;
            MidName = Function.Simplify(midName);
            LastName = Function.Simplify(lastName)!;
            FatherName = Function.Simplify(fatherName)!;
        }

        // Method - Create a new object
        public static Name Create(string firstName, string? midName, string lastName, string fatherName)
            => new(firstName, midName, lastName, fatherName);

        // Method - To string
        public override string ToString()
            => MidName is null ? $"{FirstName} {LastName}" : $"{FirstName} {MidName} {LastName}";
    }
}
