using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Employees.Enums;

namespace PizzaX.ApplicationCore.DTOs.EmployeeDTOs
{
    public sealed class EmployeeFilterDto : BaseFilterDto
    {
        public int? UserId { get; init; }

        public decimal? MinSalary { get; init; }
        public decimal? MaxSalary { get; init; }

        public bool? IsActive { get; init; }

        public EmployeeDesignation? Designation { get; init; }

        // Address-based filtering (query-friendly)
        public string? City { get; init; }
        public string? Region { get; init; }
        public string? PostalCode { get; init; }

        public DateTime? JoinedAfter { get; init; }
        public DateTime? JoinedBefore { get; init; }
    }
}
