using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CartService : ICartService
    {

        private ICartRepo _cartRepo;
        private IMapper _mapper;

        public CartService(ICartRepo cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        public void AddItem(int customerId, int productId, int quantity)
        {
            var c = new Cart
            {
                CustomerId = customerId,
                ProductId = productId,
                Quantity = quantity
            };
            _cartRepo.Add(c);

        }

        public async Task ClearCart(int customerId)
        {
            await _cartRepo.Clear(customerId);
        }

        public async Task<IEnumerable<CartDTO>> GetCart(int customerId)
        {
            var carts = await _cartRepo.GetByCustomer(customerId);
            if(carts == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<CartDTO>>(carts);
        }

        public bool RemoveItem(int cartItemId)
        {
            return _cartRepo.Remove(cartItemId);
        }
    }
}
