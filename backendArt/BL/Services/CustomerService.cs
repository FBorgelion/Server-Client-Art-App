using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(IMapper mapper, ICustomerRepo customerRepo)
        {
            _mapper = mapper;
            _customerRepo = customerRepo;
        }

        public void Add(CustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            _customerRepo.Add(customerEntity);
        }

        public bool Delete(int id)
        {
            return _customerRepo.Delete(id);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _customerRepo.GetAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public CustomerDTO Get(int id)
        {
            var customer = _customerRepo.Get(id);
            if (customer == null)
            {
                return null;
            }
            return _mapper.Map<CustomerDTO>(customer);
        }

        public bool Update(CustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            return _customerRepo.Update(customerEntity);
        }

        public bool UpdateProfile(int customerId, CustomerUpdDTO dto)
        {
            var customer = _customerRepo.Get(customerId);
            if (customer == null) return false;

            customer.ShippingAddress = dto.ShippingAddress;
            customer.PaymentInfo = dto.PaymentInfo;
            _customerRepo.Update(customer);
            return true;
        }

    }
}
