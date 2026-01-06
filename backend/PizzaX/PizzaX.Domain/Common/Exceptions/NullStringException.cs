namespace PizzaX.Domain.Common.Exceptions
{
    public sealed class NullStringException : Exception
    {
        // Constructors
        public NullStringException() : base() { }

        public NullStringException(string message) : base(message) { }
    }
}
