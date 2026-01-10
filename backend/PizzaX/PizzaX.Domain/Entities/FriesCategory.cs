using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;

namespace PizzaX.Domain.Entities
{
    public class FriesCategory : AuditableEntity
    {
        // Attributes
        public string Name { get; private set; }
        public readonly List<Fries> _fries = new();

        // Navigation properties
        public IReadOnlyCollection<Fries> Fries => _fries;

        // Constructor
        private FriesCategory(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(FriesCategory));

            Name = name;
        }

        // Method - Create new object
        public static FriesCategory Create(string name)
            => new(name);

        /*************************************************/
        /* Methods to update fries category's properties */
        /*************************************************/

        // Update name of the fries category
        public void UpdateName(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(FriesCategory));
            
            Name = name;

            MarkUpdated();
        }
    }
}
