using DAL.Repositories.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class InquiryRepo : IInquiryRepo
    {

        private readonly AppDbContext _dbContext;

        public InquiryRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Inquiry inquiry)
        {
            _dbContext.CustomerInquiries.Add(inquiry);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var inquiry = _dbContext.CustomerInquiries.FirstOrDefault(p => p.InquiryId == id);
            if (inquiry == null)
            {
                return false;
            }
            _dbContext.CustomerInquiries.Remove(inquiry);
            _dbContext.SaveChanges();
            return true;
        }

        public Inquiry Get(int id)
        {
            var inquiry = _dbContext.CustomerInquiries.FirstOrDefault(p => p.InquiryId == id);
            return inquiry;
        }

        public IEnumerable<Inquiry> GetAll()
        {
            return _dbContext.CustomerInquiries.ToList();
        }

        public bool Update(Inquiry inquiry)
        {
            var inquiryToUpd = _dbContext.CustomerInquiries.FirstOrDefault();
            if (inquiryToUpd == null)
            {
                return false;
            }
            inquiryToUpd.Response = inquiry.Response;

            _dbContext.SaveChanges();
            return true;
        }

    }
}
