using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.EmployeeDTOs;
using PizzaX.Domain.Employees.Entities;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<PagedResultDto<Employee>> GetAsync(EmployeeFilterDto filter);
    }
}
