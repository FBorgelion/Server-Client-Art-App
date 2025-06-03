using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo) 
        {
            _productRepo = productRepo;
        }

        public void AddProduct(Product product)
        {
            _productRepo.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _productRepo.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return _productRepo.GetProduct(id);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepo.UpdateProduct(product);
        }

    }
}
