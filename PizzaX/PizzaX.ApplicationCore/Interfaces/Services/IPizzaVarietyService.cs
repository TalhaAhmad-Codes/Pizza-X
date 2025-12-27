using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs;

namespace PizzaX.ApplicationCore.Interfaces.Services
{
    public interface IPizzaVarietyService
    {
        Task<PagedResultDto<PizzaVarietyDto>> GetPizzaVarietiesAsync(PizzaVarietyFilterDto filter);
    }
}
