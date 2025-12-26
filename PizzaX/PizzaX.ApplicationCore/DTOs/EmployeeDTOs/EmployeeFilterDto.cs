using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Employees.Enums;

namespace PizzaX.ApplicationCore.DTOs.EmployeeDTOs
{
    public sealed class EmployeeFilterDto : BaseFilterDto
    {
        public int? UserId { get; init; }

        public decimal? MinSalary { get; init; }
        public decimal? MaxSalary { get; init; }

        public EmployeeDesignation? Designation { get; init; }

        public bool? HasLeft { get; init; }

        // Address-based filtering (query-friendly)
        public string? City { get; init; }
        public string? Region { get; init; }
        public string? PostalCode { get; init; }

        public DateTime? JoinedFrom { get; init; }
        public DateTime? JoinedTo { get; init; }

        public DateTime? LeftFrom { get; init; }
        public DateTime? LeftTo { get; init; }
    }
}
