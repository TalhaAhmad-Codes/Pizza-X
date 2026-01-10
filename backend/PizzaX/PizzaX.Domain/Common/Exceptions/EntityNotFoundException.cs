namespace PizzaX.Domain.Common.Exceptions
{
    public sealed class EntityNotFoundException : Exception
    {
        // Constructors
        public EntityNotFoundException() : base() { }

        public EntityNotFoundException(string message) : base(message) { }
    }
}
