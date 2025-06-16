using BL.Models;

namespace BL.Services.Interfaces
{
    public interface IOrderService
    {

        public IEnumerable<OrderDTO> GetAll();

        public OrderDTO Get(int id);

        public void Add(OrderDTO order);

        //public bool Update(OrderDTO order);

        public bool Delete(int id);

        public IEnumerable<OrderDTO> GetOrdersByCustomer(int customerId);

        public IEnumerable<OrderDTO> GetOrdersByPartner(int partnerId);

        public IEnumerable<ArtisanOrderDTO> GetOrdersForArtisan(int artisanId);

        public bool UpdateOrderStatus(int orderId, string status);

        public IEnumerable<OrderDTO> GetAssignedOrders(int dpId);

        public Task<bool> UpdateOrderStatus(int orderId, int dpId, string status);

        public Task<bool> CreateOrderFromCart(int customerId);

        public IEnumerable<RevenueDTO> GetRevenue(int artisanId, string period);


    }


}
