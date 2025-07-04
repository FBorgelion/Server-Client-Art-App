﻿using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
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
            var customer = _dbContext.Customers
                .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderItems)
                .FirstOrDefault(p => p.CustomerId == id);
            if (customer == null)
            {
                return false;
            }

            foreach (var order in customer.Orders)
            {
                _dbContext.OrderItems.RemoveRange(order.OrderItems);
                _dbContext.Orders.Remove(order);
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.CustomerId == id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers
                .Include(c => c.User)
                .ToList();
        }

        public async Task<bool> Update(Customer customer)
        {
            var customerToUpd = await _dbContext.Customers.FirstOrDefaultAsync();
            if (customerToUpd == null)
            {
                return false;
            }
            customerToUpd.ShippingAddress = customer.ShippingAddress;
            customerToUpd.PaymentInfo = customer.PaymentInfo;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
