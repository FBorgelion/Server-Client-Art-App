using BL.Models;

namespace BL.Services.Interfaces
{
    public interface IInquiryService
    {

        public IEnumerable<InquiryDTO> GetAll();

        public InquiryDTO Get(int id);

        public void Add(int custId, int productId, string message);

        public bool Update(InquiryDTO inquiry);

        public bool Delete(int id);

        public IEnumerable<InquiryDTO> GetInquiriesForArtisan(int artisanId);

        public bool RespondToInquiry(int inquiryId, string response);

        public IEnumerable<InquiryDTO> GetInquiriesForCustomer(int custId);


    }


}
