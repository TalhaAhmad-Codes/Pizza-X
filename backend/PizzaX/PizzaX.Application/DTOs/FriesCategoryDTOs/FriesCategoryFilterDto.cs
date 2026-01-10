using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.FriesCetagoryDTOs
{
    public sealed class FriesCategoryFilterDto : BaseFilterDto
    {
        public string? Name { get; init; }
    }
}
