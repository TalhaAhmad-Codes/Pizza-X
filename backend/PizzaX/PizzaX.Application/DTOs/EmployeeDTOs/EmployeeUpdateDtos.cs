using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Employee;

namespace PizzaX.Application.DTOs.EmployeeDTOs.EmployeeUpdateDtos
{
    public sealed class EmployeeUpdateNameDto : BaseDto
    {
        public string FirstName { get; init; }
        public string? MidName { get; init; }
        public string LastName { get; init; }
        public string FatherName { get; init; }
    }

    public sealed class EmployeeUpdateAddressDto : BaseDto
    {
        public string House { get; init; }
        public string Area { get; init; }
        public string? Street { get; init; }
        public string City { get; init; }
        public string? Province { get; init; }
        public string? Country { get; init; }
    }

    public sealed class EmployeeUpdateCNICDto : BaseDto
    {
        public string CNIC { get; init; }
    }

    public sealed class EmployeeUpdateSalaryDto : BaseDto
    {
        public decimal Salary { get; init; }
    }

    public sealed class EmployeeUpdateJobRoleDto : BaseDto
    {
        public EmployeeJobRole JobRole { get; init; }
    }

    public sealed class EmployeeUpdateContactDto : BaseDto
    {
        public string Contact { get; init; }
    }

    public sealed class EmployeeUpdateShiftDto : BaseDto
    {
        public EmployeeShift Shift { get; init; }
    }

    public sealed class EmployeeMarkLeftDateDto : BaseDto
    {
        public DateOnly LeftDate { get; init; }
    }
}
