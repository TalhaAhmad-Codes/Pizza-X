using PizzaX.Domain.Common;

namespace PizzaX.Domain.Employees.ValueObject
{
    public sealed class Address
    {
        // Attributes
        public string Region { get; }
        public string City { get; }
        public string PostalCode { get; }

        // Constructor
        private Address(string region, string city, string postalCode)
        {
            Region = region;
            City = city;
            PostalCode = postalCode;
        }

        // Method - Create an address object
        public static Address Create(string region, string city, string postalCode)
        {
            Guard.AgainstNull(region, nameof(region));
            Guard.AgainstNull(city, nameof(city));
            Guard.AgainstNull(postalCode, nameof(postalCode));

            if (postalCode.Length < 4)
                throw new DomainException("Postal code is invalid.");

            return new Address(region, city, postalCode);
        }

        // Method - To string convertor
        public override string ToString()
        {
            return $"{PostalCode} {Region}, {City}";
        }
    }
}
