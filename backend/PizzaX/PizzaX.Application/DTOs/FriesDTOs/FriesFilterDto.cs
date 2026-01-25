using PizzaX.Application.DTOs.ProductDTOs;

namespace PizzaX.Application.DTOs.FriesDTOs
{
    public sealed class FriesFilterDto : BaseProductFilterDto
    {
        public string? Category { get; init; }
    }
}
