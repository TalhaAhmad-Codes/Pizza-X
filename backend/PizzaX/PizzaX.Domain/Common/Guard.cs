using PizzaX.Domain.ValueObjects.User;

namespace PizzaX.Domain.Common
{
    public static class Guard
    {
        // Methods - Against negative value
        public static void AgainstNegativeValue(decimal value, string name)
        {
            if (value < 0)
                throw new DomainException($"{name} can't be negative.");
        }

        public static void AgainstNegativeValue(int value, string name)
        {
            if (value < 0)
                throw new DomainException($"{name} can't be negative.");
        }

        // Methods - Against negative or zero values
        public static void AgainstZeroOrLess(decimal value, string name)
        {
            if (value <= 0)
                throw new DomainException($"{name} can't be zero or negative.");
        }

        public static void AgainstZeroOrLess(int value, string name)
        {
            if (value <= 0)
                throw new DomainException($"{name} can't be zero or negative.");
        }


        // Method - Against null / whitespace
        public static void AgainstNullOrWhitespace(string value, string name)
        {
            if (String.IsNullOrEmpty(value))
                throw new DomainException($"{name} can't be null or whitespace.");
        }

        public static void AgainstWhitespace(string? value, string name)
        {
            if (value is null) return;

            AgainstNullOrWhitespace(value, name);
        }

        // Methods - Against length limit
        public static void AgainstMinStringLength(string value, int length, string name)
        {
            if (value.Length < length)
                throw new DomainException($"{name} must have at least length of {length}.");
        }

        public static void AgainstMaxStringLength(string value, int length, string name)
        {
            if (value.Length > length)
                throw new DomainException($"{name} can't have length greater than {length}.");
        }

        // Method - Against not allowed / illegal string part
        public static void AgainstIllegalStringPart(string text, string part, string property)
        {
            if (text.Contains(part, StringComparison.OrdinalIgnoreCase))
                throw new DomainException($"{property} can't contain '{part}'.");
        }

        public static void AgainstNotContainPart(string text, string part, string property)
        {
            if (!text.Contains(part, StringComparison.OrdinalIgnoreCase))
                throw new DomainException($"{property} must contain '{part}'.");
        }

        // Method - Against password mismatch
        public static void AgainstPasswordMismatch(string password, string hash)
        {
            if (!Password.Verify(password, hash))
                throw new DomainException("Password didn't match.");
        }

        // Method - Against unauth... by admin
        public static void AgainstUnauthorizedByAdmin(bool isAuthorized)
        {
            if (!isAuthorized)
                throw new UnauthorizedAccessException("This action is unauthorized by admin");
        }

        // Method - Against invalid date ranges
        public static void AgainstInvalidDateRange(DateOnly dateA, DateOnly? dateB)
        {
            if (!dateB.HasValue) return;

            if (dateB <= dateA)
                throw new DomainException($"{dateB} can't be set before/at {dateA}.");
        }
    }
}
