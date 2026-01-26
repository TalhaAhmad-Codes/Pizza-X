using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.EmployeeDTOs;
using PizzaX.Application.Interfaces.Repositories;
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
                query = query.Where(e => e.CNIC == filterDto.CNIC);

            if (filterDto.Contact != null)
                query = query.Where(e => e.Contact == filterDto.Contact);

            if (filterDto.JoiningDate.HasValue)
                query = query.Where(e => e.JoiningDate == filterDto.JoiningDate);

            if (filterDto.LeftDate.HasValue)
                query = query.Where(e => e.LeftDate == filterDto.LeftDate);

            if (filterDto.HaveLeft.HasValue)
                query = query.Where(e => e.HasLeft == filterDto.HaveLeft);

            if (filterDto.FirstName != null)
                query = query.Where(e => e.Name.FirstName.ToLower() == filterDto.FirstName.Trim().ToLower());

            if (filterDto.MidName != null)
                query = query.Where(e => e.Name.MidName!.ToLower() == filterDto.MidName.Trim().ToLower());

            if (filterDto.LastName != null)
                query = query.Where(e => e.Name.LastName.ToLower() == filterDto.LastName.Trim().ToLower());

            if (filterDto.FatherName != null)
                query = query.Where(e => e.Name.FatherName.ToLower() == filterDto.FatherName.Trim().ToLower());

            if (filterDto.House != null)
                query = query.Where(e => e.Address.House.ToLower() == filterDto.House.Trim().ToLower());

            if (filterDto.Area != null)
                query = query.Where(e => e.Address.Area.ToLower() == filterDto.Area.Trim().ToLower());

            if (filterDto.Street != null)
                query = query.Where(e => e.Address.Street!.ToLower() == filterDto.Street.Trim().ToLower());

            if (filterDto.City != null)
                query = query.Where(e => e.Address.City.ToLower() == filterDto.City.Trim().ToLower());

            if (filterDto.Province != null)
                query = query.Where(e => e.Address.Province!.ToLower() == filterDto.Province.Trim().ToLower());

            if (filterDto.Country != null)
                query = query.Where(e => e.Address.Country!.ToLower() == filterDto.Country.Trim().ToLower());

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
