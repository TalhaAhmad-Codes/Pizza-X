using PizzaX.Application.DTOs.ProductDTOs;

namespace PizzaX.Application.DTOs.FriesDTOs
{
    public sealed class FriesDto : BaseProductDto
    {
        public Guid FriesCategoryId { get; init; }
    }
}
