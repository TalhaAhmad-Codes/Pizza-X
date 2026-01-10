namespace PizzaX.Application.DTOs.Common
{
    public abstract class BaseFilterDto
    {
        // Data fields
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
