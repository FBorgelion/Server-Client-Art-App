using DAL.Repositories.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class AdminRepo : IAdminRepo
    {

        private readonly AppDbContext _dbContext;

        public AdminRepo(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
        }

    }
}
