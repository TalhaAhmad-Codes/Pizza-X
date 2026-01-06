namespace PizzaX.Domain.Common.Exceptions
{
    public sealed class InvalidLengthException : Exception
    {
        // Constructors
        public InvalidLengthException() : base() { }

        public InvalidLengthException(string message) : base(message) { }
    }
}
