using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ArtisanOrderItemDTO
    {
        public int OrderItemId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }

    }
}
