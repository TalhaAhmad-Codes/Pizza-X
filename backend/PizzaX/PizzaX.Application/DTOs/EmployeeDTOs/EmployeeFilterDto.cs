using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Employee;

namespace PizzaX.Application.DTOs.EmployeeDTOs
{
    public sealed class EmployeeFilterDto : BaseFilterDto
    {
        // Name fields
        public string? FirstName { get; init; }
        public string? MidName { get; init; }
        public string? LastName { get; init; }
        public string? FatherName { get; init; }

        // Basic fields
        public Guid? UserId { get; init; }
        public string? CNIC { get; init; }
        public string? Contact { get; init; }
        public decimal? MinSalary { get; init; }
        public decimal? MaxSalary { get; init; }
        public EmployeeJobRole? JobRole { get; init; }
        public EmployeeShift? Shift { get; init; }
        public DateTime? JoiningDate { get; init; }
        public DateTime? LeftDate { get; init; }
        public bool? HaveLeft { get; init; }

        // Address fields
        public string? House { get; init; }
        public string? Area { get; init; }
        public string? Street { get; init; }
        public string? City { get; init; }
        public string? Province { get; init; }
        public string? Country { get; init; }
    }
}
