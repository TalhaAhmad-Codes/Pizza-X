using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Common
{
    public sealed class Address
    {
        // Attributes
        public string House { get; }
        public string Area { get; }
        public string Street { get; }
        public string City { get; }
        public string Province { get; }
        public string? Country { get; }

        // Constructors
        private Address() { }
        private Address(string house, string area, string street, string city, string province, string? country)
        {
            Guard.AgainstNullOrWhitespace(house, nameof(House));
            Guard.AgainstNullOrWhitespace(area, nameof(Area));
            Guard.AgainstNullOrWhitespace(street, nameof(Street));
            Guard.AgainstNullOrWhitespace(city, nameof(City));
            Guard.AgainstNullOrWhitespace(province, nameof(Province));
            Guard.AgainstWhitespace(country, nameof(Country));

            House = house.Trim().ToLower();
            Area = area.Trim().ToLower();
            Street = street.Trim().ToLower();
            City = city.Trim().ToLower();
            Province = province.Trim().ToLower();
            Country = country?.Trim().ToLower();
        }

        // Method - Create a new object
        public static Address Create(string house, string area, string street, string city, string province, string? country)
            => new(house, area, street, city, province, country);
    }
}
