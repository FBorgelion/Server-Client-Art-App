﻿using BL.Models;
using Domain;


namespace BL.Services.Interfaces
{
    public interface IProductService
    {

        public IEnumerable<ProductDTO> GetAllProducts();

        public ProductDTO GetProduct(int id);

        public void AddProduct(ProductDTO product);

        public bool UpdateProduct(ProductDTO product);

        public bool DeleteProduct(int id);

        public IEnumerable<ProductDTO> GetProductsByArtisan(int artisanId);

    }


}
