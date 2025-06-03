using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeliveryPartner
    {

        public int DeliveryPartnerId { get; set; }


        public User User { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<DeliveryStatusUpdate> DeliveryStatusUpdates { get; set; }

    }
}
