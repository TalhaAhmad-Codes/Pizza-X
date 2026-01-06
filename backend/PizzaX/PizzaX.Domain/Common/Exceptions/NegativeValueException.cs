namespace PizzaX.Domain.Common.Exceptions
{
    public sealed class NegativeValueException : Exception
    {
        // Constructors
        public NegativeValueException() : base() { }

        public NegativeValueException(string message) : base(message) { }
    }
}
