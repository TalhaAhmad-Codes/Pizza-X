using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Employees.Enums;

namespace PizzaX.ApplicationCore.DTOs.EmployeeDTOs
{
    public sealed class EmployeeDto : AuditableDto
    {
        public int UserId { get; init; }
        public EmployeeDesignation Designation { get; init; }
        public decimal Salary { get; init; }

        // Flattened Contact
        public string ContactNumber { get; init; }

        // Flattened Address
        public string Region { get; init; }
        public string City { get; init; }
        public string PostalCode { get; init; }

        public DateTime JoiningDate { get; init; }
        public DateTime? LeaveDate { get; init; }
    }
}
