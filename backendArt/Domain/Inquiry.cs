using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Inquiry
    {

        public int InquiryId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public DateTime CreatedAt { get; set; }


        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
