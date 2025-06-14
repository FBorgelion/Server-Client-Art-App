using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CartRepo : ICartRepo
    {

        private AppDbContext _dbContext;

        public CartRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cart>> GetByCustomer(int custId)
        {
            var carts = await _dbContext.Cart
                .Where(c => c.CustomerId == custId)
                .Include(c => c.Product)
                .Include(c => c.Customer)
                .ToListAsync();
            return carts;
        }

        public void Add(Cart item)
        {
            _dbContext.Cart.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Remove(int cartItemId)
        {
            var item = _dbContext.Cart.Find(cartItemId);
            if (item == null) return false;
            _dbContext.Cart.Remove(item);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task Clear(int customerId)
        {
            var items = await _dbContext.Cart.Where(c => c.CustomerId == customerId).ToListAsync();
            _dbContext.Cart.RemoveRange(items);
            _dbContext.SaveChanges();
        }

    }
}
