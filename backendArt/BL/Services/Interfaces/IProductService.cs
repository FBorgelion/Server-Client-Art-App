using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IProductService
    {

        public IEnumerable<Product> GetAllProducts();

        public Product GetProduct(int id);

        public void AddProduct(Product product);

        public bool UpdateProduct(Product product);

        public bool DeleteProduct(int id);
    }


}
