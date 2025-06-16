using BL.Models;
using Domain;


namespace BL.Services.Interfaces
{
    public interface ICustomerService
    {

        public IEnumerable<CustomerDTO> GetAll();

        public Task<CustomerDTO> Get(int id);

        public void Add(CustomerDTO customer);

        public Task<bool> Update(CustomerDTO customer);

        public bool Delete(int id);

        public Task<bool> UpdateProfile(int customerId, CustomerUpdDTO dto);

    }


}
