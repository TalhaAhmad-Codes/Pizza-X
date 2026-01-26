using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.EmployeeDTOs;
using PizzaX.Application.DTOs.EmployeeDTOs.EmployeeUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;
using PizzaX.Domain.ValueObjects.Common;
using PizzaX.Domain.ValueObjects.Employee;

namespace PizzaX.Application.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
            => this.repository = repository;

        public async Task<EmployeeDto> AddAsync(CreateEmployeeDto dto)
        {
            var employee = Employee.Create(
                userId: dto.UserId,
                name: Name.Create(dto.FirstName, dto.MidName, dto.LastName, dto.FatherName),
                jobRole: dto.JobRole,
                salary: Salary.Create(dto.Salary),
                contact: Contact.Create(dto.Contact),
                employeeShift: dto.Shift,
                cnic: CNIC.Create(dto.CNIC),
                joiningDate: dto.JoiningDate,
                leftDate: null,
                address: Address.Create(dto.House, dto.Area, dto.Street, dto.City, dto.Province, dto.Country)
            );

            await repository.AddAsync(employee);
            return EmployeeMapper.ToDto(employee);
        }

        public async Task<PagedResultDto<EmployeeDto>> GetAllAsync(EmployeeFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<EmployeeDto>
            {
                Items = result.Items.Select(EmployeeMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<EmployeeDto?> GetByIdAsync(Guid id)
        {
            var employee = await repository.GetByIdAsync(id);

            return employee is null ? null : EmployeeMapper.ToDto(employee);
        }

        public async Task<bool> MarkLeftDateAsync(EmployeeMarkLeftDateDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.MarkJobLeaved(dto.LeftDate);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var employee = await repository.GetByIdAsync(id);

            if (employee is null) return false;

            await repository.RemoveAsync(employee);
            return true;
        }

        public async Task<bool> UpdateAddressAsync(EmployeeUpdateAddressDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateAddress(dto.House, dto.Area, dto.Street, dto.City, dto.Province, dto.Country);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> UpdateCNICAsync(EmployeeUpdateCNICDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateCNIC(dto.CNIC);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> UpdateContactAsync(EmployeeUpdateContactDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateContact(dto.Contact);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> UpdateJobRoleAsync(EmployeeUpdateJobRoleDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateJobRole(dto.JobRole);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> UpdateNameAsync(EmployeeUpdateNameDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateName(dto.FirstName, dto.MidName, dto.LastName, dto.FatherName);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> UpdateSalaryAsync(EmployeeUpdateSalaryDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateSalary(dto.Salary);
            await repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> UpdateShiftAsync(EmployeeUpdateShiftDto dto)
        {
            var employee = await repository.GetByIdAsync(dto.Id);

            if (employee is null) return false;

            employee.UpdateEmployeeShift(dto.Shift);
            await repository.UpdateAsync(employee);
            return true;
        }
    }
}
