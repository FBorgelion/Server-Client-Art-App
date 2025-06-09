using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class InquiryDTO
    {

        public int InquiryId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string ProductTitle { get; set; }    

        public string Message { get; set; }
        public string? Response { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
