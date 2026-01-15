using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos
{
    // Update drink details
    public sealed class DrinkUpdateDetailsCompanyNameDto : BaseDto
    {
        public string CompanyName { get; init; }
    }

    public sealed class DrinkUpdateDetailsRetailerContactNumber : BaseDto
    {
        public string? RetailerContactNumber { get; init; }
    }
}
