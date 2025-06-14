using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepo
    {

        public IEnumerable<Product> GetAllProducts();

        public Task<Product> GetProduct(int id);

        public void AddProduct(Product product);

        public Task<bool> UpdateProduct(Product product);

        public bool DeleteProduct(int id);

        public IEnumerable<Product> GetProductsByArtisan(int artisanId);
    }
}
