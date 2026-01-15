namespace PizzaX.Domain.Common
{
    public sealed class DomainException : Exception
    {
        public DomainException() : base() { }
        public DomainException(string message) : base(message) { }
    }
}
