using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs.Common
{
    public abstract class BaseProductFilterDto : BaseFilterDto
    {
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public StockStatus? StockStatus { get; init; }
    }
}
