namespace PizzaX.Application.DTOs.ProductDTOs
{
    public abstract class BaseCreateProductDto
    {
        public byte[]? Image { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public string? Description { get; init; }
    }
}
