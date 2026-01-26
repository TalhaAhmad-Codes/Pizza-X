using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Common
{
    public sealed class Address
    {
        // Attributes
        public string House { get; }
        public string Area { get; }
        public string? Street { get; }
        public string City { get; }
        public string? Province { get; }
        public string? Country { get; }

        // Constructors
        private Address() { }
        private Address(string house, string area, string? street, string city, string? province, string? country)
        {
            Guard.AgainstNullOrWhitespace(house, nameof(House));
            Guard.AgainstNullOrWhitespace(area, nameof(Area));
            Guard.AgainstWhitespace(street, nameof(Street));
            Guard.AgainstNullOrWhitespace(city, nameof(City));
            Guard.AgainstWhitespace(province, nameof(Province));
            Guard.AgainstWhitespace(country, nameof(Country));

            House = house.Trim();
            Area = area.Trim();
            Street = street?.Trim();
            City = city.Trim();
            Province = province?.Trim();
            Country = country?.Trim();
        }

        // Method - Create a new object
        public static Address Create(string house, string area, string? street, string city, string? province, string? country)
            => new(house, area, street, city, province, country);

        // Method - Convert to string
        public override string ToString()
        {
            var address = "";

            // Adding house and area
            address += $"{House} {Area}";

            // Adding street
            if (Street != null)
                address += $", {Street}";

            // Adding city
            address += $", {City}";

            // Adding province and country
            if (Province != null)
                address += $", {Province}";

            if (Country != null)
                address += $", {Country}";

            return address;
        }
    }
}
