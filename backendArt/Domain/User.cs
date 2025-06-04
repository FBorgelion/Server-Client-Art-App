using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        
        public Artisan Artisan { get; set; }
        public Customer Customer { get; set; }
        public DeliveryPartner DeliveryPartner { get; set; }
        public Admin Admin { get; set; }

    }
}
