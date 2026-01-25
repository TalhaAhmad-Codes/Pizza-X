using PizzaX.Domain.Common;
using PizzaX.Domain.ValueObjects.Common;

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

            FirstName = firstName.Trim().ToLower();
            MidName = midName?.Trim().ToLower();
            LastName = lastName.Trim().ToLower();
            FatherName = fatherName.Trim().ToLower();
        }

        // Method - Create a new object
        public static Name Create(string firstName, string? midName, string lastName, string fatherName)
            => new(firstName, midName, lastName, fatherName);

        // Method - To string
        public override string ToString()
            => MidName is null ? $"{FirstName} {LastName}" : $"{FirstName} {MidName} {LastName}";
    }
}
