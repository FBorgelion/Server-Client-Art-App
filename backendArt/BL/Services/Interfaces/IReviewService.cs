using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IReviewService
    {

        public IEnumerable<ReviewDTO> GetAll();

        public IEnumerable<ReviewDTO> GetReviewsByProduct(int productId);

        public IEnumerable<ReviewDTO> GetReviewsByCustomer(int custId);

        public void Add(int custId, int productId, int ratin, string comment);

        public bool Delete(int id);

    }
}
