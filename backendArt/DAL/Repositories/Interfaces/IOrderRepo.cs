using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepo
    {

        public IEnumerable<Order> GetAll();

        public Order Get(int id);

        public Task Add(Order order);

        public Task Update(Order order);

        public bool Delete(int id);

        public IEnumerable<Order> GetOrdersByCustomer(int customerId);

        public IEnumerable<Order> GetOrdersByPartner(int partnerId);

        IEnumerable<Order> GetOrdersForArtisan(int artisanId);

        public bool UpdateOrderStatus(int orderId, string status);

        public Task AddStatusUpdate(DeliveryStatusUpdate u);

    }
}
