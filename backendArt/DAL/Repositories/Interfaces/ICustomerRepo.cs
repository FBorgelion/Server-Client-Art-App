using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface ICustomerRepo
    {

        public IEnumerable<Customer> GetAll();

        public Task<Customer> Get(int id);

        public void Add(Customer customer);

        public Task<bool> Update(Customer customer);

        public bool Delete(int id);
    }
}
