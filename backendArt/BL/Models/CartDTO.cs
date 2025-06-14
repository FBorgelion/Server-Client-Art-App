using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CartDTO
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
