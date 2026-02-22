using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.EmployeeDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.User;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<Employee>> GetAllAsync(EmployeeFilterDto filterDto)
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
                query = query.Where(e => e.CNIC == Function.Simplify(filterDto.CNIC)!);

            if (filterDto.Contact != null)
                query = query.Where(e => e.Contact == Function.Simplify(filterDto.Contact)!);

            if (filterDto.JoiningDate.HasValue)
                query = query.Where(e => e.JoiningDate == filterDto.JoiningDate);

            if (filterDto.LeftDate.HasValue)
                query = query.Where(e => e.LeftDate == filterDto.LeftDate);

            if (filterDto.HaveLeft.HasValue)
                query = query.Where(e => e.HasLeft == filterDto.HaveLeft);

            if (filterDto.FirstName != null)
                query = query.Where(e => e.Name.FirstName.ToLower() == Function.Simplify(filterDto.FirstName, true));

            if (filterDto.MidName != null)
                query = query.Where(e => e.Name.MidName!.ToLower() == Function.Simplify(filterDto.MidName, true));

            if (filterDto.LastName != null)
                query = query.Where(e => e.Name.LastName.ToLower() == Function.Simplify(filterDto.LastName, true));

            if (filterDto.FatherName != null)
                query = query.Where(e => e.Name.FatherName.ToLower() == Function.Simplify(filterDto.FatherName, true));

            if (filterDto.House != null)
                query = query.Where(e => e.Address.House.ToLower() == Function.Simplify(filterDto.House, true));

            if (filterDto.Area != null)
                query = query.Where(e => e.Address.Area.ToLower() == Function.Simplify(filterDto.Area, true));

            if (filterDto.Street != null)
                query = query.Where(e => e.Address.Street!.ToLower() == Function.Simplify(filterDto.Street, true));

            if (filterDto.City != null)
                query = query.Where(e => e.Address.City.ToLower() == Function.Simplify(filterDto.City, true));

            if (filterDto.Province != null)
                query = query.Where(e => e.Address.Province!.ToLower() == Function.Simplify(filterDto.Province, true));

            if (filterDto.Country != null)
                query = query.Where(e => e.Address.Country!.ToLower() == Function.Simplify(filterDto.Country, true));

            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Employee>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<bool> IsEligibleAsync(Guid userId)
        {
            var user = await dbContext.Set<User>().FindAsync(userId);

            return user is not null && user.UserRole != UserRole.Customer;
        }
    }
}
