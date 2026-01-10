namespace PizzaX.Domain.Common.Exceptions
{
    public sealed class ZeroOrLessException : Exception
    {
        // Constructors
        public ZeroOrLessException() : base() { }

        public ZeroOrLessException(string message) : base(message) { }
    }
}
