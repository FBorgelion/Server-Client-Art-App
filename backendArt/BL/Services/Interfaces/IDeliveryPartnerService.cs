using BL.Models;
using Domain;


namespace BL.Services.Interfaces
{
    public interface IDeliveryPartnerService
    {

        public IEnumerable<DeliveryPartnerDTO> GetAll();

        public DeliveryPartnerDTO Get(int id);

        public void Add(DeliveryPartnerDTO partner);

        public bool Update(DeliveryPartnerDTO partner);

        public bool Delete(int id);
    }


}
