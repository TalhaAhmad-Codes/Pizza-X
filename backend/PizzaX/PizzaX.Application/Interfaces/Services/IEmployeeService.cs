using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.EmployeeDTOs;
using PizzaX.Application.DTOs.EmployeeDTOs.EmployeeUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<PagedResultDto<EmployeeDto>> GetAllAsync(EmployeeFilterDto filterDto);

        // Basic methods
        Task<EmployeeDto?> GetByIdAsync(Guid id);
        Task<EmployeeDto> AddAsync(CreateEmployeeDto dto);
        Task<bool> RemoveAsync(Guid id);

        // Update methods
        Task<bool> UpdateNameAsync(EmployeeUpdateNameDto dto);
        Task<bool> UpdateAddressAsync(EmployeeUpdateAddressDto dto);
        Task<bool> UpdateCNICAsync(EmployeeUpdateCNICDto dto);
        Task<bool> UpdateSalaryAsync(EmployeeUpdateSalaryDto dto);
        Task<bool> UpdateJobRoleAsync(EmployeeUpdateJobRoleDto dto);
        Task<bool> UpdateContactAsync(EmployeeUpdateContactDto dto);
        Task<bool> UpdateShiftAsync(EmployeeUpdateShiftDto dto);
        Task<bool> MarkLeftDateAsync(EmployeeMarkLeftDateDto dto);
    }
}
