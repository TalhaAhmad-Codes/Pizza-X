using PizzaX.Domain.Exceptions;
using PizzaX.Domain.ValueObjects;
using System.Security.Authentication;

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

        // Method - Against null / whitespace
        public static void AgainstNullOrWhitespace(string value, string name)
        {
            if (String.IsNullOrEmpty(value))
                throw new NullStringException($"{name} can't be null or whitespace.");
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
