using PizzaX.Application.DTOs.BaseProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.DTOs.ProductDTOs.ProductUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
            => this.repository = repository;

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = Product.Create(
                image: dto.Image,
                unitPrice: dto.UnitPrice,
                quantity: dto.Quantity,
                description: dto.Description,
                name: dto.Name,
                categoryId: dto.CategoryId
            );

            await repository.AddAsync(product);
            return ProductMapper.ToDto(product);
        }

        public async Task<PagedResultDto<ProductDto>> GetAllAsync(ProductFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<ProductDto>
            {
                Items = result.Items.Select(ProductMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await repository.GetByIdAsync(id);

            return product is null ? null : ProductMapper.ToDto(product);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var product = await repository.GetByIdAsync(id);

            if (product is null) return false;

            await repository.RemoveAsync(product);
            return true;
        }

        public async Task<bool> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            var product = await repository.GetByIdAsync(dto.Id);

            if (product is null) return false;

            product.UpdateDescription(dto.Description);
            await repository.UpdateAsync(product);
            return true;
        }

        public async Task<bool> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var product = await repository.GetByIdAsync(dto.Id);

            if (product is null) return false;

            product.UpdateImage(dto.Image);
            await repository.UpdateAsync(product);
            return true;
        }

        public async Task<bool> UpdateNameAsync(ProductUpdateNameDto dto)
        {
            var product = await repository.GetByIdAsync(dto.Id);

            if (product is null) return false;

            product.UpdateName(dto.Name);
            await repository.UpdateAsync(product);
            return true;
        }

        public async Task<bool> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            var product = await repository.GetByIdAsync(dto.Id);

            if (product is null) return false;

            product.UpdatePrice(dto.Price);
            await repository.UpdateAsync(product);
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(ProductUpdateQuantityDto dto)
        {
            var product = await repository.GetByIdAsync(dto.Id);

            if (product is null) return false;

            product.UpdateQuantity(dto.Quantity);
            await repository.UpdateAsync(product);
            return true;
        }
    }
}
