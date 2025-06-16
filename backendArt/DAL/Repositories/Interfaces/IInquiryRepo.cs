using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IInquiryRepo
    {

        public void Add(Inquiry inquiry);

        public bool Delete(int id);

        public Inquiry Get(int id);

        public IEnumerable<Inquiry> GetAll();

        public bool Update(Inquiry inquiry);

        public IEnumerable<Inquiry> GetInquiriesForArtisan(int artisanId);

        public bool RespondToInquiry(int inquiryId, string response);

        public IEnumerable<Inquiry> GetInquiriesForCustomer(int custId);


    }
}
