using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace BL.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        private readonly IWebHostEnvironment _env;

        public ProductService(IMapper mapper, IProductRepo productRepo, IWebHostEnvironment env) 
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _env = env;
        }

        public void AddProduct(ProductAddDTO product, int artisanId)
        {
            ProductDTO productDTO = new ProductDTO { ProductId = product.ProductId, ArtisanId = artisanId, Title = product.Title, Description = product.Description, Price = product.Price, Stock = product.Stock, Images = product.Images };

            var productEntity = _mapper.Map<Product>(productDTO);
            _productRepo.AddProduct(productEntity);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _productRepo.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _productRepo.GetProduct(id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> UpdateProduct(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            return await _productRepo.UpdateProduct(productEntity);
        }

        public IEnumerable<ProductDTO> GetProductsByArtisan(int artisanId)
        {
            var products = _productRepo.GetProductsByArtisan(artisanId);
            return _mapper.Map<IEnumerable<ProductDTO>>(products); ;
        }

        public async Task<bool> DecreaseStock(int productId, int quantity)
        {
            var prod = await _productRepo.GetProduct(productId);
            if (prod == null || prod.Stock < quantity)
                return false;
            prod.Stock -= quantity;
            await _productRepo.UpdateProduct(prod);
            return true;
        }

        public async Task<ProductDTO> CreateAsync(ProductCreateDTO dto, int artisanId)
        {
            // construit l'entité
            var product = new Product
            {
                ArtisanId = artisanId,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Images = dto.Images
            };

            _productRepo.AddProduct(product);
            // SaveChanges a déjà été appelé en interne

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateAsync(int id, ProductUpdateDTO dto)
        {
            var existing = await _productRepo.GetProduct(id);
            if (existing == null) throw new KeyNotFoundException($"Product {id} not found");

            // Update champs
            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.Price = dto.Price;
            existing.Stock = dto.Stock;
            if (!string.IsNullOrWhiteSpace(dto.Images))
                existing.Images = dto.Images;

            _productRepo.UpdateProduct(existing);
        }

    }
}
