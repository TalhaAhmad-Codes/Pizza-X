using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Domain.Enums.Drink;

namespace PizzaX.Application.DTOs.DrinkDTOs
{
    public sealed class DrinkFilterDto : BaseProductFilterDto
    {
        // Data fields
        public DrinkType? DrinkType { get; init; }

        // Data fields - Drink Details
        public string? CompanyName { get; init; }
        public string? RetailerContactNumber { get; init; }
    }
}
