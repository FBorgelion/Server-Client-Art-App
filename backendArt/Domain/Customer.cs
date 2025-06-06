using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public string? ShippingAddress { get; set; }
        public string? PaymentInfo { get; set; }


        public User User { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Inquiry> CustomerInquiries { get; set; }
    }
}
