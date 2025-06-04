using BL.Models;

namespace BL.Services.Interfaces
{
    public interface IOrderItemService
    {

        public IEnumerable<OrderItemDTO> GetAll();

        public OrderItemDTO Get(int id);

        public void Add(OrderItemDTO orderItem);

        public bool Update(OrderItemDTO orderItem);

        public bool Delete(int id);
    }


}
