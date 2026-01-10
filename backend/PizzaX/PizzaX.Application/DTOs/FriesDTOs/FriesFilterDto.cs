using PizzaX.Application.DTOs.ProductDTOs;

namespace PizzaX.Application.DTOs.FriesDTOs
{
    public sealed class FriesFilterDto : BaseProductFilterDto
    {
        public Guid? FriesCetagoryId { get; init; }
    }
}
