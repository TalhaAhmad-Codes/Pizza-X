using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Employee
{
    public sealed class Salary
    {
        // Attribute
        public decimal Value { get; }

        // Constructors
        private Salary() { }
        private Salary(decimal value)
        {
            Guard.AgainstZeroOrLess(value, nameof(Salary));

            Value = value;
        }

        // Method - Create new salary object
        public static Salary Create(decimal salary)
            => new(salary);

        // Methods - Comparision operators
        public static bool operator >=(Salary salary, decimal other)
            => salary.Value >= other;

        public static bool operator <=(Salary salary, decimal other)
            => salary.Value <= other;

        // Method - Convert to string
        public override string ToString()
            => Value.ToString();
    }
}
