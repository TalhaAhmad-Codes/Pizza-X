using PizzaX.ApplicationCore.DTOs.PizzaDTOs;
using PizzaX.Domain.Pizzas.Entities;

namespace PizzaX.ApplicationCore.Factories
{
    internal static class PizzaFactory
    {
        public static Pizza Create(PizzaDto dto)
            => Pizza.Create(
                price: dto.Price,
                size: dto.Size,
                noOfPizzas: dto.NoOfPizzas,
                varietyId: dto.PizzaVarietyId,
                description: dto.Description,
                image: dto.Image
            );
    }
}
