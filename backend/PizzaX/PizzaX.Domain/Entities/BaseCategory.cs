using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;

namespace PizzaX.Domain.Entities
{
    public abstract class BaseCategory<P> : AuditableEntity where P : class
    {
        // Attribute
        public string Value { get; protected set; }
        
        // Navigation
        private readonly List<P> products = new();
        public IReadOnlyList<P> Products => products;

        // Constructors
        protected BaseCategory() { }
        protected BaseCategory(string category)
        {
            Guard.AgainstNullOrWhitespace(category, nameof(category));

            Value = Function.Simplify(category, true)!;
        }

        /*******************************/
        /* Methods - Update properties */
        /*******************************/

        public void UpdateName(string category)
        {
            Guard.AgainstNullOrWhitespace(category, nameof(category));

            Value = Function.Simplify(category, true)!;
            MarkUpdated();
        }

        // Comparision operator
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;

            return Value == obj.ToString();
        }
    }
}
