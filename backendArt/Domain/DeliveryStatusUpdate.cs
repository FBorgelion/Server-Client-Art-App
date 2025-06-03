using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeliveryStatusUpdate
    {

        public int UpdateId { get; set; }
        public int OrderId { get; set; }
        public int DeliveryPartnerId { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }


        public Order Order { get; set; }
        public DeliveryPartner DeliveryPartner { get; set; }

    }
}
