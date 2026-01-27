using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Application.DTOs.BaseCategoryDTOs.BaseCategoryUpdateDtos;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository repository;

        public ProductCategoryService(IProductCategoryRepository repository)
            => this.repository = repository;

        public async Task<BaseCategoryDto> CreateAsync(CreateBaseCategoryDto dto)
        {
            var category = ProductCategory.Create(
                category: dto.Name
            );

            await repository.AddAsync(category);
            return CategoryMapper.ProductCategoryToDto(category);
        }

        public async Task<PagedResultDto<BaseCategoryDto>> GetAllAsync(BaseCategoryFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<BaseCategoryDto>
            {
                Items = result.Items.Select(CategoryMapper.ProductCategoryToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<BaseCategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await repository.GetByIdAsync(id);
            return category is null ? null : CategoryMapper.ProductCategoryToDto(category);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var category = await repository.GetByIdAsync(id);

            if (category is null) return false;

            await repository.RemoveAsync(category);
            return true;
        }

        public async Task<bool> UpdateNameAsync(BaseCategoryUpdateNameDto dto)
        {
            var category = await repository.GetByIdAsync(dto.Id);

            if (category is null) return false;

            category.UpdateName(dto.Name);
            await repository.UpdateAsync(category);
            return true;
        }
    }
}
