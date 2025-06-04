using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class OrderItemService : IOrderItemService
    {

        private readonly IMapper _mapper;
        private readonly IOrderItemRepo _orderItemRepo;

        public OrderItemService(IMapper mapper, IOrderItemRepo orderItemRepo) 
        {
            _mapper = mapper;
            _orderItemRepo = orderItemRepo;
        }

        public void Add(OrderItemDTO orderItem)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(orderItem);
            _orderItemRepo.Add(orderItemEntity);
        }

        public bool Delete(int id)
        {
            return _orderItemRepo.Delete(id);
        }

        public IEnumerable<OrderItemDTO> GetAll()
        {
            var orderItems = _orderItemRepo.GetAll();
            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);
        }

        public OrderItemDTO Get(int id)
        {
            var orderItem = _orderItemRepo.Get(id);
            if (orderItem == null)
            {
                return null;
            }
            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public bool Update(OrderItemDTO orderItem)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(orderItem);
            return _orderItemRepo.Update(orderItemEntity);
        }

    }
}
