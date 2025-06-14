using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ICartRepo
    {
        public Task<IEnumerable<Cart>> GetByCustomer(int custId);
        public void Add(Cart item);
        public bool Remove(int cartItemId);
        public Task Clear(int customerId);

    }
}
