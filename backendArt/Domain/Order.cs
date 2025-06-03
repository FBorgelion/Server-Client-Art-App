using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int? DeliveryPartnerId { get; set; }
        public string ShippingAddress { get; set; }


        public Customer Customer { get; set; }
        public DeliveryPartner DeliveryPartner { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<DeliveryStatusUpdate> DeliveryStatusUpdates { get; set; }

    }
}
