using BL.Models;
using Domain;


namespace BL.Services.Interfaces
{
    public interface ICustomerService
    {

        public IEnumerable<CustomerDTO> GetAll();

        public CustomerDTO Get(int id);

        public void Add(CustomerDTO customer);

        public bool Update(CustomerDTO customer);

        public bool Delete(int id);
    }


}
