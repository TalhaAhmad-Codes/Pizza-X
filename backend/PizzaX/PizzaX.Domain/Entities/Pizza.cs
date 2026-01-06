using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Domain.Entities
{
    public sealed class Pizza : AuditableEntity
    {
        // Attributes
        public byte[]? Image { get; private set; }
        public decimal UnitPrice { get; private set; }
        public Size Size { get; private set; }
        public Status Status
            => (Amount > 0) ? Status.InStock : Status.OutOfStock;
        public int Amount { get; private set; }
        
        // Foriegn Attribute
        public Guid VarietyId { get; private set; }

        // Navigation Property
        public Variety Variety { get; private set; }

        // Constructors
        private Pizza() { }

        private Pizza(byte[]? image, decimal unitPrice, Size size, int amount, Guid varietyId, Variety variety)
        {
            Guard.AgainstNegativeValue(unitPrice, nameof(UnitPrice));
            Guard.AgainstNegativeValue(amount, nameof(Amount));

            Image = image;
            UnitPrice = unitPrice;
            Size = size;
            Amount = amount;
            VarietyId = varietyId;
        }

        // Method - Create a new object
        //public static Pizza Create() => new();
    }
}
