using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.Services
{
    public sealed class PizzaService : BaseProductService, IPizzaService
    {
        private readonly IPizzaRepository pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository, IProductRepository productRepository) : base(productRepository)
            => this.pizzaRepository = pizzaRepository;

        public async Task<PizzaDto> CreateAsync(CreatePizzaDto dto)
        {
            ProductDto? productDto = await GetProductByIdAsync(dto.ProductId);

            // If pizza of same variety and size already exists
            if (await pizzaRepository.GetSimilarVarietyAndSizePizzaAsync(dto.VarietyId, dto.Size) != null)
                throw new DomainException($"The pizza of {dto.VarietyId} of size {dto.Size} already exists in the database.");
            
            // Creating product first if doesn't exist
            if (productDto is null && dto.ProductDto != null)
            {
                productDto = await CreateProductAsync(dto.ProductId, new()
                {
                    Image = dto.ProductDto.Image,
                    Price = dto.ProductDto.Price,
                    Description = dto.ProductDto.Description,
                    StockStatus = dto.ProductDto.StockStatus,
                    ProductType = ProductType.Pizza
                });
            }

            // Creating pizza
            var pizza = Pizza.Create(
                productId: dto.ProductId,
                varietyId: dto.VarietyId,
                pizzaSize: dto.Size
            );
            await pizzaRepository.AddAsync(pizza);
            return PizzaMapper.ToDto(pizza, new()
            {
                ProductId = productDto!.Id,
                Price = productDto!.Price,
                Description = productDto!.Description,
                StockStatus = productDto!.StockStatus
            });
        }

        public async Task<PagedResultDto<PizzaDto>> GetAllAsync(PizzaFilterDto filterDto)
        {
            var result = await pizzaRepository.GetAllAsync(filterDto);
            var items = new List<PizzaDto>();
            
            foreach (var pizza in result.Items)
            {
                var product = await pizzaRepository.GetProductByIdAsync(pizza.ProductId);
                items.Add(PizzaMapper.ToDto(pizza, new()
                {
                    ProductId = product!.Id,
                    Price = product!.Price.UnitPrice,
                    Description = product!.Description,
                    StockStatus = product!.StockStatus
                }));
            }
            
            return new PagedResultDto<PizzaDto>()
            {
                Items = items,
                TotalCount = result.TotalCount
            };
        }

        public async Task<PizzaDto?> GetByIdAsync(Guid id)
        {
            var pizza = await pizzaRepository.GetByIdAsync(id);
            var product = await productRepository.GetByIdAsync(pizza!.ProductId);

            return pizza is null ? null :
                PizzaMapper.ToDto(pizza, new()
                {
                    ProductId = product!.Id,
                    Price = product!.Price.UnitPrice,
                    Description = product!.Description,
                    StockStatus = product!.StockStatus
                });
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var pizza = await pizzaRepository.GetByIdAsync(id);

            if (pizza is null)
                return false;

            await pizzaRepository.RemoveAsync(pizza);
            return true;
        }
    }
}
