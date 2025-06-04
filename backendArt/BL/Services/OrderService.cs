using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace BL.Services
{
    public class OrderService : IOrderService
    {

        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public OrderService(IMapper mapper, IOrderRepo orderRepo) 
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public void Add(OrderDTO order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _orderRepo.Add(orderEntity);
        }

        public bool Delete(int id)
        {
            return _orderRepo.Delete(id);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _orderRepo.GetAll();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public OrderDTO Get(int id)
        {
            var order = _orderRepo.Get(id);
            if (order == null)
            {
                return null;
            }
            return _mapper.Map<OrderDTO>(order);
        }

        public bool Update(OrderDTO order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            return _orderRepo.Update(orderEntity);
        }

        public IEnumerable<OrderDTO> GetOrdersByCustomer(int customerId)
        {
            var orders = _orderRepo.GetOrdersByCustomer(customerId);
            if (orders.IsNullOrEmpty())
            {
                return null;
            }
            return _mapper.Map<IEnumerable<OrderDTO>>(orders); ;
        }

        public IEnumerable<OrderDTO> GetOrdersByPartner(int partnerId)
        {
            var orders = _orderRepo.GetOrdersByPartner(partnerId);
            if (orders.IsNullOrEmpty())
            {
                return null;
            }
            return _mapper.Map<IEnumerable<OrderDTO>>(orders); ;
        }

    }
}
