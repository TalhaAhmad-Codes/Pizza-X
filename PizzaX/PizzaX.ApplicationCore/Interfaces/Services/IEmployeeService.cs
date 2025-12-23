using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.EmployeeDTOs;

namespace PizzaX.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<PagedResultDto<EmployeeDto>> GetEmployeesAsync(EmployeeFilterDto filter);
    }
}
