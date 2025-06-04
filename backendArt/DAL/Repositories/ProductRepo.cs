using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepo : IProductRepo
    {

        private readonly AppDbContext _dbContext;

        public ProductRepo(AppDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
           var productToUpd = _dbContext.Products.FirstOrDefault();
            if (productToUpd == null)
            {
                return false;
            }
            productToUpd.Title = product.Title;
            productToUpd.Description = product.Description;
            productToUpd.Price = product.Price;
            productToUpd.Stock = product.Stock;
            productToUpd.Images = product.Images;

            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Product> GetProductsByArtisan(int artisanId)
        {
            return  _dbContext.Products.Where(p => p.ArtisanId == artisanId) .ToList();
        }

    }
}
