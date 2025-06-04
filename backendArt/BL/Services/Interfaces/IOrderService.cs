using BL.Models;

namespace BL.Services.Interfaces
{
    public interface IOrderService
    {

        public IEnumerable<OrderDTO> GetAll();

        public OrderDTO Get(int id);

        public void Add(OrderDTO order);

        public bool Update(OrderDTO order);

        public bool Delete(int id);

        public IEnumerable<OrderDTO> GetOrdersByCustomer(int customerId);

        public IEnumerable<OrderDTO> GetOrdersByPartner(int partnerId);

    }


}
