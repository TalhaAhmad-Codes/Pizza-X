using PizzaX.ApplicationCore.DTOs.EmployeeDTOs;
using PizzaX.Domain.Employees.Entities;

namespace PizzaX.ApplicationCore.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto ToDto(Employee entity)
            => new() { 
                Id = entity.Id,
                UserId = entity.UserId,
                Designation = entity.Designation,
                Salary = entity.Salary,
                ContactNumber = entity.Contact.Number,
                Region = entity.Address.Region,
                City = entity.Address.City,
                PostalCode = entity.Address.PostalCode,
                JoiningDate = entity.JoiningDate,
                LeaveDate = entity.LeaveDate,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
    }
}
