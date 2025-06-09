using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class InquiryService : IInquiryService
    {

        private readonly IMapper _mapper;
        private readonly IInquiryRepo _inquiryRepo;

        public InquiryService(IMapper mapper, IInquiryRepo inquiryRepo) 
        {
            _mapper = mapper;
            _inquiryRepo = inquiryRepo;
        }

        public void Add(InquiryDTO inquiry)
        {
            var inquiryEntity = _mapper.Map<Inquiry>(inquiry);
            _inquiryRepo.Add(inquiryEntity);
        }

        public bool Delete(int id)
        {
            return _inquiryRepo.Delete(id);
        }

        public IEnumerable<InquiryDTO> GetAll()
        {
            var inquiries = _inquiryRepo.GetAll();
            return _mapper.Map<IEnumerable<InquiryDTO>>(inquiries);
        }

        public InquiryDTO Get(int id)
        {
            var inquiry = _inquiryRepo.Get(id);
            if (inquiry == null)
            {
                return null;
            }
            return _mapper.Map<InquiryDTO>(inquiry);
        }

        public bool Update(InquiryDTO inquiry)
        {
            var inquiryEntity = _mapper.Map<Inquiry>(inquiry);
            return _inquiryRepo.Update(inquiryEntity);
        }

        public IEnumerable<InquiryDTO> GetInquiriesForArtisan(int artisanId)
        {
            var entities = _inquiryRepo.GetInquiriesForArtisan(artisanId);
            return _mapper.Map<IEnumerable<InquiryDTO>>(entities);
        }

        public bool RespondToInquiry(int inquiryId, string response)
        {
            return _inquiryRepo.RespondToInquiry(inquiryId, response);
        }

    }

}
