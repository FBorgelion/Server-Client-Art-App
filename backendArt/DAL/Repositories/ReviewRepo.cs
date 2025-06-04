using DAL.Repositories.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ReviewRepo : IReviewRepo
    {

        private readonly AppDbContext _dbContext;

        public ReviewRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Review> GetAll()
        {
            return _dbContext.Reviews.ToList();
        }

        public IEnumerable<Review> GetReviewByProduct(int productId)
        {
            return _dbContext.Reviews.Where(o => o.ProductId == productId).ToList();
        }

        public void Add(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var review = _dbContext.Reviews.FirstOrDefault(p => p.ReviewId == id);
            if (review == null)
            {
                return false;
            }
            _dbContext.Reviews.Remove(review);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
