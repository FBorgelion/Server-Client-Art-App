using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CustomerDTO
    {

        public int CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentInfo { get; set; }

        public string Username { get; set; }

        public string email {  get; set; }
    }
}
