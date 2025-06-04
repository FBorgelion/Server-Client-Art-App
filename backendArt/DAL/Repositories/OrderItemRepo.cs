using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderItemRepo : IOrderItemRepo
    {

        private readonly AppDbContext _dbContext;

        public OrderItemRepo(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var orderItem = _dbContext.OrderItems.FirstOrDefault(p => p.OrderItemId == id);
            if (orderItem == null)
            {
                return false;
            }
            _dbContext.OrderItems.Remove(orderItem);
            _dbContext.SaveChanges();
            return true;
        }

        public OrderItem Get(int id)
        {
            var orderItem = _dbContext.OrderItems.FirstOrDefault(p => p.OrderItemId == id);
            return orderItem;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _dbContext.OrderItems.ToList();
        }

        public bool Update(OrderItem orderItems)
        {
            var orderItemToUpd = _dbContext.OrderItems.FirstOrDefault();
            if (orderItemToUpd == null)
            {
                return false;
            }
            orderItemToUpd.ProductId = orderItemToUpd.ProductId;
            orderItemToUpd.Quantity = orderItemToUpd.Quantity;
            orderItemToUpd.PriceAtPurchase = orderItemToUpd.PriceAtPurchase;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
