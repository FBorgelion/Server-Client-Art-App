using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace BL.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;

        public ProductService(IMapper mapper, IProductRepo productRepo) 
        {
            _mapper = mapper;
            _productRepo = productRepo;
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

        public ProductDTO GetProduct(int id)
        {
            var product = _productRepo.GetProduct(id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public bool UpdateProduct(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            return _productRepo.UpdateProduct(productEntity);
        }

        public IEnumerable<ProductDTO> GetProductsByArtisan(int artisanId)
        {
            var products = _productRepo.GetProductsByArtisan(artisanId);
            return _mapper.Map<IEnumerable<ProductDTO>>(products); ;
        }

    }
}
