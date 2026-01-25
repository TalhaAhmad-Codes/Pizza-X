using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.EmployeeDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PizzaXDbContext context) : base(context) { }

        public Task<PagedResultDto<Employee>> GetAllAsync(EmployeeFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.UserId.HasValue)
                query = query.Where(e => e.UserId == filterDto.UserId);

            if (filterDto.JobRole.HasValue)
                query = query.Where(e => e.JobRole == filterDto.JobRole);

            if (filterDto.Shift.HasValue)
                query = query.Where(e => e.Shift == filterDto.Shift);

            if (filterDto.MinSalary.HasValue)
                query = query.Where(e => e.Salary >= filterDto.MinSalary.Value);

            if (filterDto.MaxSalary.HasValue)
                query = query.Where(e => e.Salary <= filterDto.MaxSalary.Value);

            if (filterDto.CNIC != null)
                query = query.Where(e => e.CNIC == filterDto.CNIC);

            if (filterDto.Contact != null)
                query = query.Where(e => e.Contact == filterDto.Contact);

            if (filterDto.JoiningDate.HasValue)
                query = query.Where(e => e.JoiningDate == filterDto.JoiningDate);

            if (filterDto.LeftDate.HasValue)
                query = query.Where(e => e.LeftDate == filterDto.LeftDate);

            if (filterDto.HaveLeft.HasValue)
                query = query.Where(e => e.HasLeft == filterDto.HaveLeft);


        }
    }
}
