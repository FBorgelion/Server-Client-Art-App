using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface ICustomerRepo
    {

        public IEnumerable<Customer> GetAll();

        public Customer Get(int id);

        public void Add(Customer customer);

        public bool Update(Customer customer);

        public bool Delete(int id);
    }
}
