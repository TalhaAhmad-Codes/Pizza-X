namespace PizzaX.ApplicationCore.DTOs.PizzaDTOs
{
    public sealed class PizzaCustomizationDto
    {
        public bool ExtraCheese { get; init; }
        public bool ExtraSauce { get; init; }
        public bool ExtraToppings { get; init; }
        public int NoOfCustomizedPizzas { get; init; }

        public bool Exists => ExtraCheese || ExtraSauce || ExtraToppings;
    }
}
