namespace PizzaX.Domain.Common.Exceptions
{
    public class DuplicateEntityException : Exception
    {
        // Constructors
        public DuplicateEntityException() : base() { }

        public DuplicateEntityException(string message) : base(message) { }
    }
}
