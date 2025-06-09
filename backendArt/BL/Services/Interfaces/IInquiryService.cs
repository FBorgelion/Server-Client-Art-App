using BL.Models;

namespace BL.Services.Interfaces
{
    public interface IInquiryService
    {

        public IEnumerable<InquiryDTO> GetAll();

        public InquiryDTO Get(int id);

        public void Add(InquiryDTO inquiry);

        public bool Update(InquiryDTO inquiry);

        public bool Delete(int id);

        public IEnumerable<InquiryDTO> GetInquiriesForArtisan(int artisanId);

        public bool RespondToInquiry(int inquiryId, string response);

    }


}
