using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public abstract class BaseProductService : IBaseProductService
    {
        protected readonly IProductRepository productRepository;

        public BaseProductService(IProductRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<ProductDto> CreateProductAsync(Guid productId, CreateProductDto dto)
        {
            var product = Product.Create(
                id: productId,
                image: dto.Image,
                price: dto.Price,
                description: dto.Description,
                stockStatus: dto.StockStatus,
                productType: dto.ProductType
            );

            await productRepository.AddAsync(product);
            return ProductMapper.ToDto(product);
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return product is null ? null : ProductMapper.ToDto(product);
        }
    }
}
