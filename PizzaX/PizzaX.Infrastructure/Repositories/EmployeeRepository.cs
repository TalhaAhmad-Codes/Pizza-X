using Microsoft.EntityFrameworkCore;
using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.EmployeeDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.Domain.Employees.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    internal sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<Employee>> GetAsync(EmployeeFilterDto filter)
        {
            var query = _context.Employees.AsQueryable();

            // Applying filters
            if (filter.UserId.HasValue)
                query = query.Where(e => e.UserId == filter.UserId.Value);

            if (filter.MinSalary.HasValue)
                query = query.Where(e => e.Salary >= filter.MinSalary.Value);

            if (filter.MaxSalary.HasValue)
                query = query.Where(e => e.Salary <= filter.MaxSalary.Value);

            if (filter.Designation.HasValue)
                query = query.Where(e => e.Designation == filter.Designation.Value);

            if (filter.HasLeft.HasValue)
                query = query.Where(e => e.HasLeft == filter.HasLeft.Value);

            if (filter.City is not null)
                query = query.Where(e => e.Address.City.ToLower() == filter.City.ToLower());

            if (filter.Region is not null)
                query = query.Where(e => e.Address.Region.ToLower() == filter.Region.ToLower());

            if (filter.PostalCode is not null)
                query = query.Where(e => e.Address.PostalCode.ToLower() == filter.PostalCode.ToLower());

            if (filter.JoinedFrom.HasValue)
                query = query.Where(e => e.JoiningDate >= filter.JoinedFrom.Value);

            if (filter.JoinedTo.HasValue)
                query = query.Where(e => e.JoiningDate <= filter.JoinedTo.Value);

            if (filter.LeftFrom.HasValue)
                query = query.Where(e => e.LeftDate >= filter.LeftFrom.Value);

            if (filter.LeftTo.HasValue)
                query = query.Where(e => e.LeftDate <= filter.LeftTo.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<Employee>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
