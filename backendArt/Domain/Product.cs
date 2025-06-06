using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {

        public int ProductId { get; set; }
        public int ArtisanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public string? Images { get; set; }


        public Artisan Artisan { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Inquiry> Inquiries { get; set; }




    }
}
