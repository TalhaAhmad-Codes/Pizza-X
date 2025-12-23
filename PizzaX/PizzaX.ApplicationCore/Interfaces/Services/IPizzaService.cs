using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaDTOs;

namespace PizzaX.ApplicationCore.Interfaces.Services
{
    public interface IPizzaService
    {
        Task<PagedResultDto<PizzaDto>> GetPizzasAsync(PizzaFilterDto filter);
    }
}
