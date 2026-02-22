using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Domain.Entities
{
    public sealed class DealItem : AuditableEntity
    {
        // Attributes
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public Quantity Quantity { get; private set; }

        // Relation
        public Guid DealId { get; private set; }
        public Deal Deal { get; private set; }

        // Constructors
        private DealItem() { }
        private DealItem(Guid productId, int quantity, Guid dealId)
        {
            ProductId = productId;
            DealId = dealId;
            Quantity = Quantity.Create(quantity);
        }

        // Method - Create a new deal item
        public static DealItem Create(Guid productId, int quantity, Guid dealId)
            => new(productId, quantity, dealId);

        /*******************************/
        /* Methods - Update Properties */
        /*******************************/

        // Update quantity
        public void UpdateQuantity(int quantity)
        {
            Quantity = Quantity.Create(quantity);
            MarkUpdated();
        }

        // Change product
        public void ChangeProduct(Guid productId)
        {
            ProductId = productId;
        }
    }
}
