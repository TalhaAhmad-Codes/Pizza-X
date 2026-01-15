using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IPizzaService : IProductUpdateService
    {
        Task<PagedResultDto<PizzaDto>> GetAllAsync(PizzaFilterDto filterDto);
    }
}
