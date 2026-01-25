namespace PizzaX.Domain.ValueObjects.Employee
{
    public sealed class CNIC
    {
        // Attribute
        public string Value { get; }
        
        // Constructos
        private CNIC() { }
        private CNIC(string value)
        {
            Value = value;
        }

        // Method - Create new object
        public static CNIC Create(string cnic)
            => new(cnic);
    }
}
