using PizzaX.Application.DTOs.EmployeeDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto ToDto(Employee employee)
            => new()
            {
                // Audit fileds
                Id = employee.Id,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt,

                // Normal fields
                UserId = employee.UserId,
                CNIC = employee.CNIC.Value,
                Contact = employee.Contact.Value,
                Salary = employee.Salary.Value,
                JobRole = employee.JobRole,
                Shift = employee.Shift,
                JoiningDate = employee.JoiningDate,
                LeftDate = employee.LeftDate,

                // Name fields
                FullName = employee.Name.ToString(),
                FatherName = employee.Name.FatherName,

                // Address field
                Address = employee.Address.ToString()
            };
    }
}
