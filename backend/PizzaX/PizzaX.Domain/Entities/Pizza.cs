using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Domain.Entities
{
    public sealed class Pizza : AuditableEntity
    {
        // Attributes
        public Guid ProductId { get; private set; }
        public Guid VarietyId { get; private set; }
        public PizzaSize Size { get; private set; }
        
        // Navigation
        public Product Product { get; private set; }
        public PizzaVariety Variety { get; private set; }

        // Constructors
        private Pizza() { }
        
        private Pizza(Guid productId, Guid varietyId, PizzaSize pizzaSize)
        {
            ProductId = productId;
            VarietyId = varietyId;
            Size = pizzaSize;
        }

        public static Pizza Create(Guid productId, Guid varietyId, PizzaSize pizzaSize)
            => new(productId, varietyId, pizzaSize);
    }
}
