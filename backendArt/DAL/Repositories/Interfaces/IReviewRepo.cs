using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IReviewRepo
    {

        public IEnumerable<Review> GetAll();

        public IEnumerable<Review> GetReviewByProduct(int productId);

        public void Add(Review review);

        public bool Delete(int id);

    }
}
