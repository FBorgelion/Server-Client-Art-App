using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IDeliveryPartnerRepo
    {

        public IEnumerable<DeliveryPartner> GetAll();

        public DeliveryPartner Get(int id);

        public void Add(DeliveryPartner partner);

        public bool Update(DeliveryPartner partner);

        public bool Delete(int id);
    }
}
