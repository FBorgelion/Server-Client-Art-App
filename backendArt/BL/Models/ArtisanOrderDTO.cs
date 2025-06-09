using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ArtisanOrderDTO
    {

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalForArtisan { get; set; }  

        public List<ArtisanOrderItemDTO> Items { get; set; }

    }
}
