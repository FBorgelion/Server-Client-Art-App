using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderItemRepo
    {

        public IEnumerable<OrderItem> GetAll();

        public OrderItem Get(int id);

        public void Add(OrderItem orderItem);

        public bool Update(OrderItem orderItem);

        public bool Delete(int id);
    }
}
