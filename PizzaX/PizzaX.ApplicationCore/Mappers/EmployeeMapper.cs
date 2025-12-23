using PizzaX.ApplicationCore.DTOs.EmployeeDTOs;
using PizzaX.Domain.Employees.Entities;

namespace PizzaX.ApplicationCore.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto ToDto(Employee employee)
            => new() { 
                Id = employee.Id,
                UserId = employee.UserId,
                Designation = employee.Designation,
                Salary = employee.Salary,
                ContactNumber = employee.Contact.Number,
                Region = employee.Address.Region,
                City = employee.Address.City,
                PostalCode = employee.Address.PostalCode,
                JoiningDate = employee.JoiningDate,
                LeaveDate = employee.LeaveDate,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
    }
}
