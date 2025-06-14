using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class OrderDTO
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int? DeliveryPartnerId { get; set; }
        public string ShippingAddress { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
