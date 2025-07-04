﻿using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
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


        public IEnumerable<Inquiry> GetInquiriesForArtisan(int artisanId)
            => _dbContext.CustomerInquiries
                  .Include(i => i.Product)
                  .Where(i => i.Product.ArtisanId == artisanId)
                  .OrderByDescending(i => i.CreatedAt)
                  .ToList();

        public IEnumerable<Inquiry> GetInquiriesForCustomer(int custId)
            => _dbContext.CustomerInquiries
                  .Include(i => i.Product)
                  .Where(i => i.CustomerId == custId)
                  .OrderByDescending(i => i.CreatedAt)
                  .ToList();

        public bool RespondToInquiry(int inquiryId, string response)
        {
            var inq = _dbContext.CustomerInquiries.FirstOrDefault(i => i.InquiryId == inquiryId);
            if (inq == null) return false;

            inq.Response = response;
            _dbContext.SaveChanges();
            return true;
        }

    }
}
