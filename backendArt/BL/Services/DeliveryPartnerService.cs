using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class DeliveryPartnerService : IDeliveryPartnerService
    {

        private readonly IMapper _mapper;
        private readonly IDeliveryPartnerRepo _partnerRepo;

        public DeliveryPartnerService(IMapper mapper, IDeliveryPartnerRepo partnerRepo)
        {
            _mapper = mapper;
            _partnerRepo = partnerRepo;
        }

        public void Add(DeliveryPartnerDTO partner)
        {
            var partnerEntity = _mapper.Map<DeliveryPartner>(partner);
            _partnerRepo.Add(partnerEntity);
        }

        public bool Delete(int id)
        {
            return _partnerRepo.Delete(id);
        }

        public IEnumerable<DeliveryPartnerDTO> GetAll()
        {
            var partners = _partnerRepo.GetAll();
            return _mapper.Map<IEnumerable<DeliveryPartnerDTO>>(partners);
        }

        public DeliveryPartnerDTO Get(int id) {
            var partner = _partnerRepo.Get(id);
            if (partner == null)
            {
                return null;
            }
            return _mapper.Map<DeliveryPartnerDTO>(partner);
        }

        public bool Update(DeliveryPartnerDTO partner)
        {
            var partnerEntity = _mapper.Map<DeliveryPartner>(partner);
            return _partnerRepo.Update(partnerEntity);
        }

    }
}
