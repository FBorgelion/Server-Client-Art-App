using DAL.Repositories.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly AppDbContext _dbContext;

        public CustomerRepo(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(p => p.CustomerId == id);
            if (customer == null)
            {
                return false;
            }
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return true;
        }

        public Customer Get(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(p => p.CustomerId == id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public bool Update(Customer customer)
        {
            var customerToUpd = _dbContext.Customers.FirstOrDefault();
            if (customerToUpd == null)
            {
                return false;
            }
            customerToUpd.ShippingAddress = customer.ShippingAddress;
            customerToUpd.PaymentInfo = customer.PaymentInfo;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
