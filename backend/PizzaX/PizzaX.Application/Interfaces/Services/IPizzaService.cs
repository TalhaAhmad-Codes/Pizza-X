using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IPizzaService : IBaseProductService
    {
        Task<PagedResultDto<PizzaDto>> GetAllAsync(PizzaFilterDto filterDto);
        Task<PizzaDto?> GetPizzaByIdAsync(Guid id);
        Task<PizzaDto> CreatePizzaAsync(CreatePizzaDto dto);
        Task<bool> RemovePizzaAsync(Guid id);
    }
}
