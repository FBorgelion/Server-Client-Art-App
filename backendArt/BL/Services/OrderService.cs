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
        private readonly IProductRepo _productRepo;
        private readonly ICartRepo _cartRepo;

        private static readonly string[] AllowedStatuses = { "InProduction", "Shipped" ,"PickedUp", "InTransit", "Delivered" };

        public OrderService(IMapper mapper, IOrderRepo orderRepo, IProductRepo productRepo, ICartRepo cartRepo) 
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _cartRepo = cartRepo;
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

        //public bool Update(OrderDTO order)
        //{
        //    var orderEntity = _mapper.Map<Order>(order);
        //    return _orderRepo.Update(orderEntity);
        //}

        public IEnumerable<OrderDTO> GetOrdersByCustomer(int customerId)
        {
            var orders = _orderRepo.GetOrdersByCustomer(customerId);
            if (orders == null)
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

        public IEnumerable<ArtisanOrderDTO> GetOrdersForArtisan(int artisanId)
        {
            IEnumerable<Order> orders = _orderRepo.GetOrdersForArtisan(artisanId);
            return _mapper.Map<IEnumerable<ArtisanOrderDTO>>(orders);
        }

        public bool UpdateOrderStatus(int orderId, string status)
        {
            if (string.Equals(status.ToLower(), "InProduction".ToLower()) || string.Equals(status.ToLower(), "Shipped".ToLower()))
            {
                return _orderRepo.UpdateOrderStatus(orderId, status);
            }
            return false;
        }

        public IEnumerable<OrderDTO> GetAssignedOrders(int dpId)
        {
            var orders = _orderRepo.GetOrdersByPartner(dpId);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task <bool> UpdateOrderStatus(int orderId, int dpId, string status)
        {
            if (!AllowedStatuses.Contains(status, StringComparer.OrdinalIgnoreCase))
                return false;

            var order = _orderRepo.Get(orderId);
            if (order == null || order.DeliveryPartnerId != dpId)
                return false;

            var update = new DeliveryStatusUpdate
            {
                OrderId = orderId,
                DeliveryPartnerId = dpId,
                Status = status,
                TimeStamp = DateTime.UtcNow
            };
             await _orderRepo.AddStatusUpdate(update);

            order.Status = status;
            await _orderRepo.Update(order);

            return true;
        }

        public async Task<bool> CreateOrderFromCart(int customerId)
        {
            var cartItems = await _cartRepo.GetByCustomer(customerId);
            if (!cartItems.Any()) return false;

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                Status = "InProduction",
                ShippingAddress = cartItems.First().Customer.ShippingAddress,
                TotalAmount = cartItems.Sum(ci => ci.Product.Price * ci.Quantity),
                OrderItems = cartItems
                    .Select(ci => new OrderItem
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        PriceAtPurchase = ci.Product.Price
                    })
                    .ToList()
            };

            foreach (var line in order.OrderItems)
            {
                var prod = await _productRepo.GetProduct(line.ProductId);
                if (prod == null || prod.Stock < line.Quantity)
                    return false; // stock manquant
                prod.Stock -= line.Quantity;
                await _productRepo.UpdateProduct(prod);
            }

            await _orderRepo.Add(order);

            await _cartRepo.Clear(customerId);

            return true;
        }

    }
}
