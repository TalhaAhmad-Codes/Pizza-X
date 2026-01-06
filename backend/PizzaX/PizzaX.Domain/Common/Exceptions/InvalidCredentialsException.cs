namespace PizzaX.Domain.Common.Exceptions
{
    public sealed class InvalidCredentialsException : Exception
    {
        // Constructors
        public InvalidCredentialsException() : base() { }

        public InvalidCredentialsException(string message) : base(message) { }
    }
}
