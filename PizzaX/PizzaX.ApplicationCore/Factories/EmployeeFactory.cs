using PizzaX.ApplicationCore.DTOs.EmployeeDTOs;
using PizzaX.Domain.Employees.Entities;
using PizzaX.Domain.Employees.ValueObject;

namespace PizzaX.ApplicationCore.Factories
{
    internal static class EmployeeFactory
    {
        public static Employee Create(EmployeeDto dto)
            => Employee.Create(
                userId: dto.UserId,
                designation: dto.Designation,
                salary: dto.Salary,
                contact: Contact.Create(number: dto.ContactNumber),
                address: Address.Create(
                    region: dto.Region,
                    city: dto.City,
                    postalCode: dto.PostalCode
                ),
                joinedDate: dto.JoinedDate,
                leftDate: dto.LeftDate
            );
    }
}
