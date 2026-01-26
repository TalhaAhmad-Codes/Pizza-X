using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Employee;

namespace PizzaX.Application.DTOs.EmployeeDTOs
{
    public sealed class EmployeeDto : BaseAuditableDto
    {
        public string FullName { get; init; }
        public string FatherName { get; init; }
        public Guid UserId { get; init; }
        public string CNIC { get; init; }
        public string Contact { get; init; }
        public decimal Salary { get; init; }
        public EmployeeJobRole JobRole { get; init; }
        public EmployeeShift Shift { get; init; }
        public DateOnly JoiningDate { get; init; }
        public DateOnly? LeftDate { get; init; }
        public string Address { get; init; }
    }
}
