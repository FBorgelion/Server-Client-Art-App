using BL.Models;
using Domain;


namespace BL.Services.Interfaces
{
    public interface IProductService
    {

        public IEnumerable<ProductDTO> GetAllProducts();

        public Task<ProductDTO> GetProduct(int id);

        public void AddProduct(ProductAddDTO product, int artisanId);

        public Task<bool> UpdateProduct(ProductDTO product);

        public bool DeleteProduct(int id);

        public IEnumerable<ProductDTO> GetProductsByArtisan(int artisanId);

        public Task<bool> DecreaseStock(int productId, int quantity);


    }


}
