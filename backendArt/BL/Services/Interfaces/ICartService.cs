using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartDTO>> GetCart(int customerId);
        public void AddItem(int customerId, int productId, int quantity);
        public bool RemoveItem(int cartItemId);
        public Task ClearCart(int customerId);
    }

}
