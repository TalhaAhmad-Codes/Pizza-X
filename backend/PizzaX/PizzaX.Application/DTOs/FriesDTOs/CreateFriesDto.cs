using PizzaX.Application.DTOs.ProductDTOs;

namespace PizzaX.Application.DTOs.FriesDTOs
{
    public sealed class CreateFriesDto : BaseCreateProductDto
    {
        public Guid FriesCategoryId { get; init; }
    }
}
