using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthenticationRepo
    {

        private readonly AppDbContext _dbContext;

        public AuthenticationRepo(AppDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetByUsername(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            return user;
        }

        public void Add(User user, string salt)
        {
            user.Salt = salt;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

    }
}
