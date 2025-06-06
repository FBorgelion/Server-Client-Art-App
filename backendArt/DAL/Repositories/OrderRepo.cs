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
    public class OrderRepo : IOrderRepo
    {

        private readonly AppDbContext _dbContext;

        public OrderRepo(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(p => p.OrderId == id);
            if (order == null)
            {
                return false;
            }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return true;
        }

        public Order Get(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(p => p.OrderId == id);
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public bool Update(Order order)
        {
            var orderToUpd = _dbContext.Orders.FirstOrDefault();
            if (orderToUpd == null)
            {
                return false;
            }
            orderToUpd.Status = order.Status;
            orderToUpd.TotalAmount = order.TotalAmount;
            orderToUpd.ShippingAddress = order.ShippingAddress;

            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Order> GetOrdersByCustomer(int customerId)
        {
            return _dbContext.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public IEnumerable<Order> GetOrdersByPartner(int partnerId)
        {
            return _dbContext.Orders.Where(o => o.DeliveryPartnerId == partnerId).ToList();
        }

    }
}
