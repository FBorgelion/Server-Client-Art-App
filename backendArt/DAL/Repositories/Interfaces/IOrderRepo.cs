using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepo
    {

        public IEnumerable<Order> GetAll();

        public Order Get(int id);

        public void Add(Order order);

        public bool Update(Order order);

        public bool Delete(int id);

        public IEnumerable<Order> GetOrdersByCustomer(int customerId);

        public IEnumerable<Order> GetOrdersByPartner(int partnerId);

        IEnumerable<Order> GetOrdersForArtisanAsync(int artisanId);
    }
}
