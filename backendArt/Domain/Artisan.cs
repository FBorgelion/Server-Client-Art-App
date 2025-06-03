using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Artisan
    {

        // PK = User.UserId
        public int ArtisanId { get; set; }
        public string ProfileDescription { get; set; }


        public User User { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
