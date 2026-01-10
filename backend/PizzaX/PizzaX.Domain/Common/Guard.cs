using PizzaX.Domain.Common.Exceptions;
using PizzaX.Domain.ValueObjects.User;

namespace PizzaX.Domain.Common
{
    public static class Guard
    {
        // Methods - Against negative value
        public static void AgainstNegativeValue(decimal value, string name)
        {
            if (value < 0)
                throw new NegativeValueException($"{name} can't be negative.");
        }

        public static void AgainstNegativeValue(int value, string name)
        {
            if (value < 0)
                throw new NegativeValueException($"{name} can't be negative.");
        }

        // Methods - Against negative or zero values
        public static void AgainstZeroOrLess(decimal value, string name)
        {
            if (value <= 0)
                throw new ZeroOrLessException($"{name} can't be zero or negative.");
        }

        public static void AgainstZeroOrLess(int value, string name)
        {
            if (value <= 0)
                throw new ZeroOrLessException($"{name} can't be zero or negative.");
        }


        // Method - Against null / whitespace
        public static void AgainstNullOrWhitespace(string value, string name)
        {
            if (String.IsNullOrEmpty(value))
                throw new NullStringException($"{name} can't be null or whitespace.");
        }

        // Method - Against whitespace only
        public static void AgainstWhitespace(string? value, string name)
        {
            // Return if the value is null, because it is acceptable
            if (value is null)
                return;

            // It only checks for whitespace not null
            AgainstNullOrWhitespace(value, name);
        }

        // Methods - Against length limit
        public static void AgainstLowerLengthLimit(string value, int length, string name)
        {
            if (value.Length < length)
                throw new InvalidLengthException($"{name} must have at least length of {length}.");
        }

        public static void AgainstGreaterLengthLimit(string value, int length, string name)
        {
            if (value.Length > length)
                throw new InvalidLengthException($"{name} can't have length greater than {length}.");
        }

        // Method - Against password mismatch
        public static void AgainstPasswordMismatch(string password, string hash)
        {
            if (!Password.Verify(password, hash))
                throw new InvalidCredentialsException("Password didn't match.");
        }

        // Method - Against unauth... by admin
        public static void AgainstUnauthorizedByAdmin(bool isAuthorized)
        {
            if (!isAuthorized)
                throw new UnauthorizedAccessException("This action is unauthorized by admin");
        }
    }
}
