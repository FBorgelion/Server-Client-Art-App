using DAL.Repositories.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DeliveryPartnerRepo : IDeliveryPartnerRepo
    {

        private readonly AppDbContext _dbContext;

        public DeliveryPartnerRepo(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(DeliveryPartner partner)
        {
            _dbContext.DeliveryPartners.Add(partner);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var partner = _dbContext.DeliveryPartners.FirstOrDefault(p => p.DeliveryPartnerId == id);
            if (partner == null)
            {
                return false;
            }
            _dbContext.DeliveryPartners.Remove(partner);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<DeliveryPartner> GetAll()
        {
            return _dbContext.DeliveryPartners.ToList();
        }

        public DeliveryPartner Get(int id)
        {
            var partner = _dbContext.DeliveryPartners.FirstOrDefault(p => p.DeliveryPartnerId == id);
            return partner;
        }

        public bool Update(DeliveryPartner partner)
        {
            throw new NotImplementedException();
        }
    }
}
